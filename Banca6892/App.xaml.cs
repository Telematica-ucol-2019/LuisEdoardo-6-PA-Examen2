using System;
using Xamarin.Forms;
using Banca6892.View6892;
using Xamarin.Forms.Xaml;

namespace Banca6892
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Principal6892());
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
