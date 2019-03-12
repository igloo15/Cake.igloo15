using System.Net;
using System;
using System.IO;
using System.Collections.Generic;

namespace Cake.igloo15.MarkdownDocument
{

    internal class MarkdownPage
    {
        public string Id { get; private set; }
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public List<string> NextPages { get; private set; } = new List<string>();
        public List<string> MarkdownLinks { get; private set; } = new List<string>();

        public List<MarkdownHeader> MarkdownHeaders { get; private set; } = new List<MarkdownHeader>();

        public string GetIdentifier()
        {
            return String.IsNullOrEmpty(Id) ? FileName.LinkId() : Id.LinkId();
        }

        public string GenerateContent(Dictionary<string, MarkdownPage> pages)
        {
            var identifier = GetIdentifier();
            var content = File.ReadAllText(FilePath);

            foreach(var header in MarkdownHeaders)
            {
                header.Anchor = $"{identifier}-{header.GetAnchorLink()}";
                content = content.Replace(header.GetOriginalString(), header.GetMarkdownString());
            }

            foreach(var link in MarkdownLinks)
            {                
                var items = link.Split('#');
                if(items.Length < 2)
                    continue;

                var pageIdentifier = "";
                if(!String.IsNullOrEmpty(items[0]))
                {
                    var fileName = Path.GetFileName(items[0]);
                    if(pages.ContainsKey(fileName))
                    {
                        pageIdentifier = pages[fileName].GetIdentifier();
                    }
                }

                content = content.Replace(link, $"#{pageIdentifier}-{items[1]}");
            }

            return content;
        }


        public static MarkdownPage Generate(string path)
        {
            if(!File.Exists(path))
                return null;

            var fileName = Path.GetFileName(path);

            var page = new MarkdownPage()
            {
                FilePath = path,
                FileName = fileName
            };

            var lines = File.ReadAllLines(path);
            foreach(var line in lines)
            {
                var result = Utility.ParseLine(line);
                if(result.Type != null)
                {
                    switch(result.Type)
                    {
                        case "id":
                            page.Id = result.Value;
                            break;
                        case "next":
                            page.NextPages.Add(result.Value);
                            break;
                        case "MarkdownLink": 
                            page.MarkdownLinks.Add(result.Value);
                            break;
                        case "MarkdownHeader":
                            page.MarkdownHeaders.Add(MarkdownHeader.CreateHeader(result.Value));
                            break;
                    }
                }
            }
            return page;
        }

    }

}