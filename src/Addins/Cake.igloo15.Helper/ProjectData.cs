using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Common.Tools;
using Cake.Common.Tools.GitVersion;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// The type of data stored in project data
    /// </summary>
    public enum ProjectDataType 
    {
        /// <summary>
        /// Public data is set during runtime and can be seen when project data is dumped
        /// </summary>
        Public,
        /// <summary>
        /// Private data is set during runtime and cannot be seen when project data is dumped
        /// </summary>
        Private,
    }

    /// <summary>
    /// A generic class used to store project data
    /// </summary>
    public class ProjectData
    {
        private Dictionary<string, object> _internalData = new Dictionary<string, object>();
        private Dictionary<string, object> _privateData = new Dictionary<string, object>();
        private Dictionary<string, ArgumentValue> _arguments = new Dictionary<string, ArgumentValue>();

        /// <summary>
        /// Indexer for the project data it will search in order the following data: Public, Private, Arguments
        /// </summary>
        /// <value>The value to be set at key</value>
        public object this[string key]
        {
            get
            {
                return Get(key);
            }

            set
            {
                Set(key, value);
            }
        }

        /// <summary>
        /// The General Cake Context
        /// </summary>
        /// <value>The Cake Context</value>
        public ICakeContext Context { get; }

        /// <summary>
        /// The Git Version
        /// </summary>
        public GitVersion ProjectVersion { get; set; }

        /// <summary>
        /// The current task
        /// </summary>
        public ICakeTaskInfo CurrentTask { get; set; }

        /// <summary>
        /// The Project Data Constructor
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <param name="arguments">The optional argument properties</param>
        public ProjectData(ICakeContext context, Dictionary<string, ArgumentValue> arguments = null)
        {
            Context = context;
            _arguments = arguments ?? new Dictionary<string, ArgumentValue>();
            
        }

        /// <summary>
        /// Short hand for getting a string
        /// </summary>
        /// <param name="key">The key to get string value of</param>
        /// <returns>The value as a string</returns>
        public string GetStr(string key)
        {
            return GetString(key);
        }

        /// <summary>
        /// Returns a string value of the given key
        /// </summary>
        /// <param name="key">The key to search on</param>
        /// <returns>A string value</returns>
        public string GetString(string key)
        {
            return Get(key).ToString();
        }

        /// <summary>
        /// Returns a value of the specified type
        /// </summary>
        /// <param name="key">The key to search on</param>
        /// <typeparam name="T">The type to cast value to</typeparam>
        /// <returns>The value as the type defined</returns>
        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        /// <summary>
        /// Gets the object representation of data stored in ProjectData
        /// </summary>
        /// <param name="key">The key to access</param>
        /// <returns>The found data</returns>
        public object Get(string key)
        {
            if(_internalData.ContainsKey(key))
            {
                return _internalData[key];
            }

            if(_privateData.ContainsKey(key))
            {
                return _privateData[key];
            }

            if(_arguments.ContainsKey(key))
            {
                return _arguments[key].Value;
            }

            throw new Exception($"Could not find Key {key}");
        }

        /// <summary>
        /// Gets an argument defined via the constructor
        /// </summary>
        /// <param name="key">The key to search on</param>
        /// <typeparam name="T">The type to cast value to</typeparam>
        /// <returns>The argument value as type T</returns>
        public T GetArg<T>(string key)
        {
            return _arguments[key].GetValue<T>();
        }

        /// <summary>
        /// Returns the ArgumentValue
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ArgumentValue GetArgValue(string key)
        {
            return _arguments[key];
        }

        /// <summary>
        /// Set a private property with given key and value. This value will not show up when printing the values of this object via ToString()
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public ProjectData SetPrivate(string key, object value)
        {
            Set(key, value, ProjectDataType.Private);
            return this;
        }

        /// <summary>
        /// This will set the data for the first time as either Public or Private depending on passed type (Public is default). If data already exists at the key it will attempt to update the data and ignore the passed project data type. If you intend to override an argument the 4th param can be used to ensure overriden
        /// </summary>
        /// <param name="key">The key to set</param>
        /// <param name="value">The value to set</param>
        /// <param name="type">The type of data being set</param>
        /// <param name="overrideNonDefaultArgument">Override argument data if it is not default</param>
        /// <returns></returns>
        public ProjectData Set(string key, object value, ProjectDataType type = ProjectDataType.Public, bool overrideNonDefaultArgument = false)
        {
            if(ContainsKey(key))
                Update(key, value, overrideNonDefaultArgument);
            else if(type == ProjectDataType.Public)
                _internalData[key] = value;
            else
                _privateData[key] = value;

            return this;
        }

        /// <summary>
        /// Will update a specific piece of data it returns false if data doesn't already exist. if you want to override your passed in arguments you must set last param to true 
        /// </summary>
        /// <param name="key">The key to update</param>
        /// <param name="value">The value to update</param>
        /// <param name="overrideNonDefaultArgument">Defaults to false, if true it will override an argument regardless of if its default or not, while false it will only update argument if argument is default value</param>
        /// <returns>True if key is updated, False if key is not updated</returns>
        public bool Update(string key, object value, bool overrideNonDefaultArgument = false)
        {
            if(_internalData.ContainsKey(key))
            {
                _internalData[key] = value;
                return true;
            }

            if(_privateData.ContainsKey(key))
            {
                _privateData[key] = value;
                return true;
            }
                
            if(_arguments.ContainsKey(key))
            {
                var argVal = GetArgValue(key);
                if(argVal.IsDefault || overrideNonDefaultArgument)
                {
                    argVal.Value = value;
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Checks if key is in project data
        /// </summary>
        /// <param name="key">The key to check on</param>
        /// <returns>True if key is found, False if key is not found</returns>
        public bool ContainsKey(string key)
        {
            return _internalData.ContainsKey(key) || _privateData.ContainsKey(key) || _arguments.ContainsKey(key);
        }

        /// <summary>
        /// Print the values of all data in project data except private data
        /// </summary>
        /// <returns>A string formatted with all data</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nProject Data:\n");

            sb.AppendLine("\nProperties:\n");
            foreach(var kvp in _internalData)
            {
                sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value}");
            }
            
            sb.AppendLine("\nArguments:\n");
            foreach(var kvp in _arguments)
            {
                if(!kvp.Value.IsPrivate)
                    sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value.Value.ToString()}");
            }

            return sb.ToString();
        }
    }
}