using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFMvsevm.Core.HTTP.Scraper;

namespace XFMvsevm.Services
{
    public class ScraperService : IScraperService
    {
        public CoreScraper _coreScraper => DependencyService.Get<CoreScraper>();

        public Task<ScrapeResult> ScrapeMvsevmAsync(
            string url,
            IEnumerable<string> keywords,
            CancellationToken cancellationToken)
        {
            return _coreScraper.ScrapeMvsevmAsync(url, keywords, cancellationToken);
        }
    }
}
