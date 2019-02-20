using System.Collections.Generic;
using System.ComponentModel;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// Extensions to allow for generic arguments or environments
    /// </summary>
    public static class ArgumentExtensions
    {
        private static Dictionary<string, object> _globalArguments = new Dictionary<string, object>();

        /// <summary>
        /// Get an Argument, EnvironmentVariable, or Default Value resolved in that order
        /// It will also add the argument to GlobalArguments
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="name">The name of the argument or environment variable</param>
        /// <param name="defaultValue">The default value</param>
        /// <param name="prefix">Optional prefix on the environment variable</param>
        /// <typeparam name="T">The type of value expected</typeparam>
        /// <returns>The Value</returns>
        [CakeMethodAlias]
        public static T ArgumentOrEnvironmentVariable<T> (this ICakeContext context, string name, T defaultValue, string prefix = null)
        {
            var environmentVariableName = prefix != null ? $"{prefix}{name}" : name;

            var envValue = context.Environment.GetEnvironmentVariable(environmentVariableName);
            var argValue = context.Arguments.GetArgument(name);

            T newDefaultValue = string.IsNullOrEmpty(envValue) ? defaultValue : Convert<T>(envValue);

            var value =  argValue == null ? newDefaultValue : Convert<T>(argValue);

            _globalArguments[name] = value;

            return value;
        }

        [CakePropertyAlias]
        public static Dictionary<string, object> GlobalArguments(this ICakeContext context)
        {
            return _globalArguments;
        } 
        
        private static T Convert<T>(string value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(value);
        }
    
    }
}