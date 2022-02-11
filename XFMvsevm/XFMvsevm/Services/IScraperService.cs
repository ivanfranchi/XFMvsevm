using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFMvsevm.Core.HTTP.Scraper;

namespace XFMvsevm.Services
{
    public interface IScraperService
    {
        Task<ScrapeResult> ScrapeMvsevmAsync(
            string url,
            IEnumerable<string> keywords,
            CancellationToken cancellationToken);
    }
}
