using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XFMvsevm.ViewModels;
using XFMvsevm.Views;

namespace XFMvsevm
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
