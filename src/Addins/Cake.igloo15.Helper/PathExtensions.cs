using System.IO;
using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Common.IO;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// Extensions used for pathing, directories, and files
    /// </summary>
    public static class PathExtensions
    {
        /// <summary>
        /// Combine the paths to create one path
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="paths">The paths to combine</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string CombinePaths(this ICakeContext context, params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        /// Creates a directory if it doesn't exist and if it already exists it cleans it
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="path">The path to perform action on</param>
        [CakeMethodAlias]
        public static void CleanCreateDirectory(this ICakeContext context, string path)
        {
            var dir = context.FileSystem.GetDirectory(path);
            if(!dir.Exists)
            {
                dir.Create();
            }

            context.CleanDirectory(dir.Path);
        }
        
    }
}