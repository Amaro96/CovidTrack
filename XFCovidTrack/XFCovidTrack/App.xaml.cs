using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Models;
using XFCovidTrack.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Com.OneSignal;

namespace XFCovidTrack
{
    public partial class App : Application
    {
        public static ObservableCollection<Country> _countries { get; set; }
        public App()
        {
            InitializeComponent();


            if(App.Current.Properties.ContainsKey("Main") == false)
            {

            MainPage = new  NavigationPage(new GetStartPage());
            }
            else
            {
                MainPage = new NavigationPage(new XFCovidTrack.Views.MainPage());
            }
            OneSignal.Current.StartInit("7ebb30ca-7bb3-474b-ba30-5f490c4c8041").EndInit();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc3Mjc0QDMxMzgyZTMxMmUzMEw5ZzlaY1RCT3kvOUhtRE9zUlpLWFBDV29ocC9PUmFraVU2VzhjNE91MVk9");
        }

        protected override void OnStart()
        {
            OneSignal.Current.RegisterForPushNotifications();
        }

        public static string Convert(string continent)
        {
            if (continent == "Africa")
                return "Africa";
            if (continent == "Europe")
                return "Europa";


            return continent;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
