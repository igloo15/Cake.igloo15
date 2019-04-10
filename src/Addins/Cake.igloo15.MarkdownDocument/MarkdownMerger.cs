using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.igloo15.MarkdownDocument 
{
    internal class MarkdownMerger
    {
        private string _filePath;
        public MarkdownMerger(string path)
        {
            _filePath = path;
        }

        public void Process(string newFile)
        {
            MarkdownPage page = MarkdownPage.Generate(_filePath);
            if(page == null)
                throw new FileNotFoundException("Could not find entry file", _filePath);

            var allPages = LoadPage(page);

            var pageLookup = allPages.ToDictionary((p) => p.FileName);

            File.WriteAllText(newFile, GenerateContent(pageLookup, page));
        }

        private List<MarkdownPage> LoadPage(MarkdownPage page)
        {
            List<MarkdownPage> pages = new List<MarkdownPage>();
            if(page == null)
                return pages;

            pages.Add(page);
            var dir = Path.GetDirectoryName(page.FilePath);
            foreach(var nextPagePath in page.NextPages)
            {
                var file = Path.Combine(dir, nextPagePath);
                var nextPage = MarkdownPage.Generate(file);
                var nextPages = LoadPage(nextPage);
                pages.AddRange(nextPages);
            }
            
            return pages;
        }

        private string GenerateContent(Dictionary<string, MarkdownPage> pages, MarkdownPage page)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(page.GenerateContent(pages));
            foreach(var nextPageId in page.NextPages)
            {
                var formattedNextPageId = nextPageId.LinkId();
                var nextPage = pages.Values.FirstOrDefault(p => p.GetIdentifier() == formattedNextPageId);

                if(nextPage != null)
                {
                    sb.AppendLine(GenerateContent(pages, nextPage));
                }
                else
                {
                    sb.AppendLine($"FAILED TO FIND PAGE {nextPageId}");
                }
            }

            return sb.ToString();
        }
    }
}