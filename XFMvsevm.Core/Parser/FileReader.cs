using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace XFMvsevm.Core.Parser
{
    public static class FileReader
    {
        public static IEnumerable<string> ReadFile(string rawText)
        {
            var lines = GetLines(rawText);
            var goodRows = Search4KeyWords(lines);
            string tmp;

            foreach (var row in goodRows)
            {
                tmp = row;
                tmp = CleanRowStuff(tmp);
                tmp = ReplaceSpecificStuff(tmp);
                yield return tmp;
            }
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
                tmp = Regex.Replace(line, pattern, "");
                result.Add(tmp);
            }

            return result;
        }

        private static IEnumerable<string> Search4KeyWords(IEnumerable<string> list)
        {
            var predicate = PredicateBuilder.False<string>();

            foreach (var word in Keywords())
            {
                string temp = word;
                predicate = predicate.Or(s => s.ToLower().Contains(temp.ToLower()));
            }

            return list.Where(predicate.Compile());
        }

        private static IEnumerable<string> Keywords()
        {
            return new List<string>
            {
                "open",
                "fee"
            };
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
