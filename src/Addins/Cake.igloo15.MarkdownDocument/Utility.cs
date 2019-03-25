using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.MarkdownDocument
{
    /// <summary>
    /// Methods for generating a merged markdown file
    /// </summary>
    internal static class Utility
    {
        public const string StartIndex = "<!--";

        public const string EndIndex = "-->";

        public const string UrlIndex = "](";
        public const string UrlEnd = ")";

        public static (string Type, string Value) ParseLine(string line)
        {
            if(line.StartsWith(StartIndex))
            {
                var newLine = line.Replace(StartIndex, "").Replace(EndIndex, "");

                var items = newLine.Split(':');
                if(items.Length > 1)
                {
                    return (items[0], items[1]);
                }
            }

            if(line.Contains(UrlIndex))
            {
                var urlStart = line.IndexOf(UrlIndex);
                var urlEnd = line.IndexOf(UrlEnd);
                var url = line.Substring(urlStart+2, urlEnd-urlStart-2);
                return ("MarkdownLink", url);
            }

            if(line.StartsWith("#")) 
            {
                return ("MarkdownHeader", line);
            }

            return (null, null);
        }

        public static string LinkId(this string text)
        {
            return text.Replace(" ", "-").Replace(".", "-").ToLower();
        }

        public static string FindIdentifier(this Dictionary<string, MarkdownPage> pages, string fileName)
        {
            if(pages.ContainsKey(fileName))
            {
                return pages[fileName].GetIdentifier();
            }

            return null;
        }

    }


}