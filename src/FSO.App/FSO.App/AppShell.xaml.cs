using System;
using System.Collections.Generic;
using FSO.App.ViewModels;
using FSO.App.Views;
using Xamarin.Forms;

namespace FSO.App
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
