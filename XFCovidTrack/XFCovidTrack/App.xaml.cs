using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Models;
using XFCovidTrack.Views;

namespace XFCovidTrack
{
    public partial class App : Application
    {
        public static ObservableCollection<Country> countries { get; }
        public App()
        {
            InitializeComponent();

            MainPage = new  NavigationPage(new GetStartPage());
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
