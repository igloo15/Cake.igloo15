using System.IO;
using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Core.Diagnostics;

namespace Cake.igloo15.Helper
{
    public static class ReplaceKeyExtensions
    {
        
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