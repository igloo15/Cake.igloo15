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
        /// <param name="newMergeFile">The file to output to</param>
        [CakeMethodAlias]
        public static void MergeMarkdownDocuments(this ICakeContext context, string entryFile, string newMergeFile)
        {
            new MarkdownMerger(entryFile).Process(newMergeFile);
        }

    }
}
