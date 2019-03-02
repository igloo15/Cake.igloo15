using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Common.Tools;
using Cake.Common.Tools.GitVersion;

namespace Cake.igloo15.Helper
{
    public class ProjectData
    {
        private Dictionary<string, object> _internalData = new Dictionary<string, object>();
        private Dictionary<string, object> _privateData = new Dictionary<string, object>();
        private Dictionary<string, object> _arguments = new Dictionary<string, object>();

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

        public ICakeContext Context { get; }

        public GitVersion Version { get; set; }

        public ProjectData(ICakeContext context, Dictionary<string, object> arguments = null)
        {
            Context = context;
            _arguments = arguments ?? new Dictionary<string, object>();
        }
        public string GetString(string key)
        {
            return GetProperty<string>(key);
        }

        public T GetProperty<T>(string key)
        {
            return (T)this[key];
        }

        public T GetArgument<T>(string key)
        {
            return (T)_arguments[key];
        }

        public void SetPrivateProperty(string key, object value)
        {
            _privateData[key] = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nPROJECT DATA INFO:\n");

            sb.AppendLine("\nPROPERTIES:\n");
            foreach(var kvp in _internalData)
            {
                sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value}");
            }
            
            sb.AppendLine("\nARGUMENTS:\n");
            foreach(var kvp in _arguments)
            {
                sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value.ToString()}");
            }

            return sb.ToString();
        }
    }
}