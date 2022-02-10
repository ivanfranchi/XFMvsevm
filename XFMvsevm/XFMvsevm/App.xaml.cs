using Xamarin.Forms;
using XFMvsevm.Core.HTTP.Scraper;
using XFMvsevm.Services;

namespace XFMvsevm
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CoreScraper>();
            DependencyService.Register<ScraperService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
