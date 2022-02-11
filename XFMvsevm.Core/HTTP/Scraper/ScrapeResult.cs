using System.Collections.Generic;

namespace XFMvsevm.Core.HTTP.Scraper
{
    public class ScrapeResult
    {
        public string Url { get; set; }
        public int Count { get; set; }
        public IEnumerable<string> Results { get; set; }
    }
}
