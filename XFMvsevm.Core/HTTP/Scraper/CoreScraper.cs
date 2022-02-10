using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFMvsevm.Core.Parser;

namespace XFMvsevm.Core.HTTP.Scraper
{
    public class CoreScraper
    {
        public async Task<IEnumerable<string>> ScrapeMvsevmAsync(CancellationToken cancellationToken)
        {
            var urls = new List<string>();
            urls.Add("http://www.computinghistory.org.uk/pages/28568/Visiting/");

            var client = MotivatedHttpClient.MotivateClient();
            var message = MotivatedHttpClient.GetEnhancedMessage(urls[0]);
            var responseBody = await MotivatedHttpClient.GetMessage(client, message, cancellationToken);

            return FileReader.ReadFile(responseBody);
        }
    }
}
