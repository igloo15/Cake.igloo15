using System;

namespace Cake.igloo15.MarkdownDocument
{
    internal class MarkdownHeader 
    {
        public string MarkdownText { get; set; }

        public string Text { get; set; }

        public string Anchor { get; set; }

        public string GetMarkdownString()
        {
            return $"{MarkdownText} <a name=\"{Anchor}\"></a>{Text}";
        }

        public string GetOriginalString()
        {
            return $"{MarkdownText} {Text}";
        }

        public string GetAnchorLink()
        {
            return Text.LinkId();
        }

        public static MarkdownHeader CreateHeader(string line)
        {
            var firstSpace = line.IndexOf(" ");

            var header = new MarkdownHeader();

            header.MarkdownText = line.Substring(0, firstSpace);
            header.Text = line.Substring(firstSpace + 1, line.Length - firstSpace - 1);

            return header;
        }
    }
}