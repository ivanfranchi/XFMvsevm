using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace XFMvsevm.Core.HTTP
{
    internal class MotivatedHttpClient
    {
        public static HttpClient MotivateClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                UseCookies = false
            };
            HttpClient client = new HttpClient(httpClientHandler);

            return client;
        }

        public static HttpRequestMessage GetEnhancedMessage(string urlToScrape)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, urlToScrape);
            message.Headers.Add("Cookie", "CONSENT=YES+shp.gws-20220120-0-RC1.en+FX+515");
            return message;
        }

        internal static async Task<string> GetMessage(
            HttpClient client,
            HttpRequestMessage message,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await client.SendAsync(message, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
