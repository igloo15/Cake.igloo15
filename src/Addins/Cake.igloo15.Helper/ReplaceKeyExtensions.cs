using System.IO;
using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Core.Diagnostics;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// Extension for replacing key values in files
    /// </summary>
    public static class ReplaceKeyExtensions
    {
        
        /// <summary>
        /// This method will search for files in the given searchPath and replace any key found with the given new value
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="key">The key to be replaced</param>
        /// <param name="newValue">The new value to replace key with</param>
        /// <param name="searchPath">The search path may include globbing wildcards</param>
        [CakeMethodAlias]
        public static void ReplaceKey(this ICakeContext context, string key, string newValue, string searchPath)
        {
            var files = context.Globber.GetFiles(searchPath);
            

            foreach(var file in files)
            {
                var filePath = file.FullPath;
                if(!File.Exists(filePath))
                    continue;

                var contents = File.ReadAllText(filePath);

                contents = contents.Replace(key, newValue);

                File.WriteAllText(filePath, contents);

                context.Log.Information($"Key {key} replaced with {newValue} in {filePath}");
            }
        }
    }
}