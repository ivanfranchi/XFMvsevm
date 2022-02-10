using System.ComponentModel;
using Xamarin.Forms;
using XFMvsevm.ViewModels;

namespace XFMvsevm.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}