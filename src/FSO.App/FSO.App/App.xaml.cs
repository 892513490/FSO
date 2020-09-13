using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FSO.App.Services;
using FSO.App.Views;

namespace FSO.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
