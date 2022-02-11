using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFMvsevm.Core.HTTP.Parser;

namespace XFMvsevm.Core.HTTP.Scraper
{
    public class CoreScraper
    {
        public async Task<ScrapeResult> ScrapeMvsevmAsync(
            string url, 
            IEnumerable<string> keywords,
            CancellationToken cancellationToken)
        {
            var client = MotivatedHttpClient.MotivateClient();
            var message = MotivatedHttpClient.GetEnhancedMessage(url);
            var responseBody = await MotivatedHttpClient.GetMessage(client, message, cancellationToken);

            var result = FileReader.ReadFile(keywords, responseBody);
            result.Url = url;
            return result;
        }
    }
}
