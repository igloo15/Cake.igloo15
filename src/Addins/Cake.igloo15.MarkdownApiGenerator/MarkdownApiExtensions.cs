using System.Text;
using System;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Igloo15.MarkdownApi.Core;
using Igloo15.MarkdownApi.Core.Interfaces;
using Igloo15.MarkdownApi.Core.Themes;
using Igloo15.MarkdownApi.Core.Themes.Default;

namespace Cake.igloo15.MarkdownApi
{
    /// <summary>
    /// Extensions that allow execution of MarkdownGenerator
    /// </summary>
    public static class MarkdownApiExtensions
    {
        /// <summary>
        /// Generate Markdown Api Documentation based on C# dll and Xml Comments
        /// </summary>
        /// <param name="context">The ICakeContext</param>
        /// <param name="searchPath">The path to search for dlls and xml comments</param>
        /// <param name="outputPath">The path to output the markdown files</param>
        /// <param name="theme">Optional theme used to define the format of the markdown files</param>
        [CakeMethodAlias]
        public static void GenerateMarkdownApi(this ICakeContext context, string searchPath, string outputPath, ITheme theme = null)
        {
            var project = MarkdownApiGenerator.GenerateProject(searchPath, "", null);
            theme = theme ?? new DefaultTheme(new DefaultOptions{
                BuildNamespacePages = true,
                BuildTypePages = true,
                RootFileName = "README.md",
                RootTitle = "API",
                ShowParameterNames = true
            });


            project.Build(new DefaultTheme(new DefaultOptions
                    {
                        BuildNamespacePages = true,
                        BuildTypePages = true,
                        RootFileName = "README.md",
                        RootTitle = "API",
                        ShowParameterNames = true
                    }
                ),
                outputPath
            );
        }

        /// <summary>
        /// Generate Markdown Api using default themes but with specificed options
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="searchPath">The search path for dll and xml files</param>
        /// <param name="outputPath">The path to put the api documentation</param>
        /// <param name="options">The default options for default theme</param>
        [CakeMethodAlias]
        public static void GenerateMarkdownApi(this ICakeContext context, string searchPath, string outputPath, DefaultOptions options)
        {
            context.GenerateMarkdownApi(searchPath, outputPath, new DefaultTheme(options));
        }

        /// <summary>
        /// Create the dll search area based on root folder
        /// </summary>
        /// <param name="context">The ICakeContext</param>
        /// <param name="rootFolder">The root folder to search under</param>
        /// <param name="filter">Filter found folders</param>
        /// <returns>The create search area</returns>
        [CakeMethodAlias]
        public static string CreateSearchArea(this ICakeContext context, string rootFolder, Func<DirectoryPath, bool> filter = null)
        {
            var folders = context.Globber.GetDirectories(rootFolder+"/**/*");

            var allowedFolders = filter != null ? folders.Where(f => filter(f)) : folders;

            StringBuilder sb = new StringBuilder();
            foreach(var folder in allowedFolders)
            {
                sb.Append(folder.FullPath).Append("/*.dll").Append(";");
            }

            return sb.ToString();
        }
    }
}