using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMvsevm.ViewModels;

namespace XFMvsevm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}