using System.Collections.Generic;
using System.ComponentModel;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Common.Diagnostics;

namespace Cake.igloo15.Helper
{

    /// <summary>
    /// An internal ArgumentValue created from the ArgumentOrEnvironmentValue extension
    /// </summary>
    public class ArgumentValue
    {
        /// <summary>
        /// True if the value is the default argument value and false if the value was passed in via an argument to script
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// True if the data should be hidden from logging
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// The internal generic value of the argument
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Constructs the argument value
        /// </summary>
        /// <param name="value">The argument value</param>
        /// <param name="isDefault">Whether the value is default</param>
        /// <param name="isPrivate">Whether the value is private defaults to false</param>
        public ArgumentValue(object value, bool isDefault, bool isPrivate = false)
        {
            Value = value;
            IsDefault = isDefault;
            IsPrivate = isPrivate;
        }

        /// <summary>
        /// Returns the Value as a specific type
        /// </summary>
        /// <typeparam name="T">The specific type to convert internal value</typeparam>
        /// <returns>The internal value or the default of the Type</returns>
        public T GetValue<T>()
        {
            if(Value is T newVal)
            {
                return newVal;
            }
            return default(T);
        }
    }

    /// <summary>
    /// Extensions to allow for generic arguments or environments
    /// </summary>
    public static class ArgumentExtensions
    {
        

        private static Dictionary<string, ArgumentValue> _globalArguments = new Dictionary<string, ArgumentValue>();

        /// <summary>
        /// Get an Argument, EnvironmentVariable, or Default Value resolved in that order
        /// It will also add the argument to GlobalArguments
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="name">The name of the argument or environment variable</param>
        /// <param name="defaultValue">The default value</param>
        /// <param name="isPrivate">If set to true the argument value will be considered private and not shown when logging</param>
        /// <param name="prefix">Optional prefix on the environment variable</param>
        /// <typeparam name="T">The type of value expected</typeparam>
        /// <returns>The Value</returns>
        [CakeMethodAlias]
        public static T ArgumentOrEnvironmentVariable<T> (this ICakeContext context, string name, T defaultValue, bool isPrivate = false, string prefix = null)
        {
            var environmentVariableName = prefix != null ? $"{prefix}{name}" : name;

            var envValue = context.Environment.GetEnvironmentVariable(environmentVariableName);
            var argValue = context.Arguments.GetArgument(name);

            T newDefaultValue = string.IsNullOrEmpty(envValue) ? defaultValue : Convert<T>(envValue);

            var value =  argValue == null ? newDefaultValue : Convert<T>(argValue);

            var argResult = new ArgumentValue(value, argValue == null, isPrivate);
            
            _globalArguments[name] = argResult;

            return value;
        }

        /// <summary>
        /// Global Arguments properties this property contains all the arguments defined using ArgumentOrEnvironmentVariable
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <returns></returns>
        [CakePropertyAlias]
        public static Dictionary<string, ArgumentValue> GlobalArguments(this ICakeContext context)
        {
            return _globalArguments;
        } 

        /// <summary>
        /// Print all arguments except private ones
        /// </summary>
        /// <param name="context">The Cake Context</param>
        [CakeMethodAlias]
        public static void PrintArguments(this ICakeContext context)
        {
            context.Information("\nArguments:\n"); 
            foreach(var argVal in _globalArguments)
            {
                if(!argVal.Value.IsPrivate)
                    context.Information($"{argVal.Key.PadRight(40)}{argVal.Value.Value.ToString()}");
            }
        }
        
        private static T Convert<T>(string value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(value);
        }
    
    }
}