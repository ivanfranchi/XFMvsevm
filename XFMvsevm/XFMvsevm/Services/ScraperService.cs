using EnsureThat;
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
        
        //CoreScraper _coreScraper;
        //public ScraperService(CoreScraper coreScraper)
        //{
        //    EnsureArg.IsNotNull(coreScraper, nameof(CoreScraper));

        //    _coreScraper = coreScraper;
        //}

        public ScraperService()
        {
            
        }

        public async Task<IEnumerable<string>> ScrapeMvsevmAsync(CancellationToken cancellationToken)
        {
            var tmp = await _coreScraper.ScrapeMvsevmAsync(cancellationToken);
            return tmp;
        }
    }
}
