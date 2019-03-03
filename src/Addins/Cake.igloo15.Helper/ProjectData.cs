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
    /// A generic class used to store project data
    /// </summary>
    public class ProjectData
    {
        private Dictionary<string, object> _internalData = new Dictionary<string, object>();
        private Dictionary<string, object> _privateData = new Dictionary<string, object>();
        private Dictionary<string, object> _arguments = new Dictionary<string, object>();

        /// <summary>
        /// Indexer for the project data it will search in order the following data: Public, Private, Arguments
        /// </summary>
        /// <value>The value to be set at index</value>
        public object this[string index]
        {
            get
            {
                if(_internalData.ContainsKey(index))
                {
                    return _internalData[index];
                }

                if(_privateData.ContainsKey(index))
                {
                    return _privateData[index];
                }

                if(_arguments.ContainsKey(index))
                {
                    return _arguments[index];
                }

                throw new Exception($"Could not find Key {index}");
            }

            set
            {
                _internalData[index] = value;
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
        public GitVersion Version { get; set; }

        /// <summary>
        /// The Project Data Constructor
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <param name="arguments">The optional argument properties</param>
        public ProjectData(ICakeContext context, Dictionary<string, object> arguments = null)
        {
            Context = context;
            _arguments = arguments ?? new Dictionary<string, object>();
        }

        /// <summary>
        /// Returns a string value of the given key
        /// </summary>
        /// <param name="key">The key to search on</param>
        /// <returns>A string value</returns>
        public string GetString(string key)
        {
            return GetProperty<string>(key);
        }

        /// <summary>
        /// Returns a value of the specified type
        /// </summary>
        /// <param name="key">The key to search on</param>
        /// <typeparam name="T">The type to cast value to</typeparam>
        /// <returns>The value as the type defined</returns>
        public T GetProperty<T>(string key)
        {
            return (T)this[key];
        }

        /// <summary>
        /// Gets an argument defined via the constructor
        /// </summary>
        /// <param name="key">The key to search on</param>
        /// <typeparam name="T">The type to cast value to</typeparam>
        /// <returns>The argument value as type T</returns>
        public T GetArgument<T>(string key)
        {
            return (T)_arguments[key];
        }

        /// <summary>
        /// Set a private property with given key and value. This value will not show up when printing the values of this object via ToString()
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void SetPrivateProperty(string key, object value)
        {
            _privateData[key] = value;
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
                sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value.ToString()}");
            }

            return sb.ToString();
        }
    }
}