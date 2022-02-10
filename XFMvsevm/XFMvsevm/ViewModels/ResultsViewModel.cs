using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFMvsevm.Services;

namespace XFMvsevm.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        //private readonly IScraperService _scraperService;
        public IScraperService _scraperService => DependencyService.Get<IScraperService>();

        public ResultsViewModel()
        {
            Title = "Results";

            Init();
        }

        //public ResultsViewModel(IScraperService scraperService)
        //{
        //    EnsureArg.IsNotNull(scraperService);
        //    _scraperService = scraperService;

        //    Init();
        //}

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

        private async Task RunScrape()
        {
            var res = await _scraperService.ScrapeMvsevmAsync(default);
            
            var linearRes = "";

            foreach (var str in res)
            {
                linearRes += str + Environment.NewLine + Environment.NewLine;
            }

            SearchResults = linearRes;
        }
    }
}