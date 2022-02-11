using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using XFMvsevm.Core.HTTP.Scraper;

namespace XFMvsevm.Core.HTTP.Parser
{
    public static class FileReader
    {
        public static ScrapeResult ReadFile(IEnumerable<string> keywords, string rawText)
        {
            var lines = GetLines(rawText);
            var goodRows = Search4KeyWords(lines, keywords);
            string tmp;
            var results = new List<string>();

            foreach (var row in goodRows)
            {
                tmp = row;
                tmp = CleanRowStuff(tmp);
                tmp = ReplaceSpecificStuff(tmp);
                results.Add(tmp);
            }

            return new ScrapeResult
            {
                Count = results.Count,
                Results = results
            };
        }

        private static IEnumerable<string> GetLines(string rawText)
        {
            string pattern = @"<[^>]*>";
            var separators = new string[]
            {
                Environment.NewLine,
                "<br />",
                "<br/>",
                "<br>"
            };

            var lines = new List<string>();
            var result = new List<string>();

            lines.AddRange(rawText.Split(separators, StringSplitOptions.RemoveEmptyEntries));

            string tmp;
            foreach (var line in lines)
            {
                if (line.Contains("background-color") || line.Contains("function()"))
                {
                    continue;
                }

                tmp = Regex.Replace(line, pattern, "");
                result.Add(tmp + "♣"); //"♣" to be removed. Used as line terminator
            }

            return result;
        }

        private static IEnumerable<string> Search4KeyWords(IEnumerable<string> list, IEnumerable<string> keywords)
        {
            var predicate = PredicateBuilder.False<string>();

            foreach (var word in keywords)
            {
                string temp = word;
                predicate = predicate.Or(s => s.ToLower().Contains(temp.ToLower()));
            }

            return list.Where(predicate.Compile());
        }

        private static string CleanRowStuff(string line)
        {
            line = line.Replace("&nbsp;", " ");
            line = line.Replace("&pound;", "£");
            line = line.Replace("  ", Environment.NewLine);
            return line;
        }

        static string ReplaceSpecificStuff(string line)
        {
            line = line.Replace("A: ", $"{Environment.NewLine}A: ");
            line = line.Replace($"{Environment.NewLine} Q: ", "Q: ");
            line = line.Replace("Q: ", $"{Environment.NewLine}{Environment.NewLine}Q: ");

            return line;
        }
    }
}
