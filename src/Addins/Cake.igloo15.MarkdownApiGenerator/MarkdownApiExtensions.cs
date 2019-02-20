using Cake.Core;
using Cake.Core.Annotations;
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
    }
}