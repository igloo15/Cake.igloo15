using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.MarkdownDocument
{
    /// <summary>
    /// Methods for generating a merged markdown file
    /// </summary>
    public static class MarkdownMethods
    {

        /// <summary>
        /// Generate a merged markdown file using the entry file as the first point of contact
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="entryFile">The entry file</param>
        /// <param name="newFile">The file to output to</param>
        [CakeMethodAlias]
        public static void GenerateMarkdownDocument(this ICakeContext context, string entryFile, string newFile)
        {
            new MarkdownMerger(entryFile).Process(newFile);
        }

    }
}
