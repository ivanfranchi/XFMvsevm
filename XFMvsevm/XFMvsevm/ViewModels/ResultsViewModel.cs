using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFMvsevm.Core.HTTP.Scraper;
using XFMvsevm.Services;

namespace XFMvsevm.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public IScraperService _scraperService => DependencyService.Get<IScraperService>();

        public ResultsViewModel()
        {
            Title = "Results";

            Init();
        }

        public ICommand SearchCommand { get; set; }

        private string searchResults = "";
        public string SearchResults
        {
            get => searchResults;
            set => SetProperty(ref searchResults, value);
        }

        private void Init()
        {
            SearchCommand = new Command(async () => await RunScrape());
        }

        private static IEnumerable<string> Keywords()
        {
            return new List<string>
            {
                "open",
                "fee"
            };
        }

        private static IEnumerable<string> Urls()
        {
            return new List<string>
            {
                "http://www.computinghistory.org.uk/pages/28568/Visiting/",
            };
        }

        private async Task RunScrape()
        {
            var scrapeResults = new List<ScrapeResult>();

            foreach (var url in Urls())
            {
                var res = await _scraperService.ScrapeMvsevmAsync(url, Keywords(), default);
                scrapeResults.Add(res);
            }

            string linearRes = "";
            foreach (var res in scrapeResults)
            {
                linearRes += "♣" + res.Url + Environment.NewLine + Environment.NewLine;
                foreach (var str in res.Results)
                {
                    linearRes += str;
                }

                linearRes += Environment.NewLine;
                linearRes += "------------------------------------------------------";
                linearRes += Environment.NewLine + Environment.NewLine;
            }
            SearchResults = linearRes;
        }
    }
}