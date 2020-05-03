using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XFCovidTrack.Interfaces;
using XFCovidTrack.ThemeResources;

namespace XFCovidTrack.ViewModels
{
   public class MainPageViewModel : BaseViewModel
    {
        public Command ChangeThemeAppCommand { get; }
        public MainPageViewModel()
        {
            ChangeThemeAppCommand = new Command(ExecuteChangeThemeAppCommand);
        }
        public bool AppDarkTheme
        {
            get => Preferences.Get("appDarkTheme", false);
            set => Preferences.Set("appDarkTheme", value);
        }
        public async Task GetAll()
        {
            SetDarkTheme(AppDarkTheme);
        }
        public void SubscribeChangeLanguage()
        {
         
            MessagingCenter.Subscribe<TesteViewModel, bool>(this, "changeAppTheme", (s, param) =>
            {
                AppDarkTheme = param;
                SetDarkTheme(param);
            });
         
        }
        public void UnsubscribeEvents()
        {
           
            MessagingCenter.Unsubscribe<TesteViewModel>(this, "changeAppTheme");
           
        }
        private void ExecuteChangeThemeAppCommand()
        {
            SetDarkTheme(true);
        }

        void SetDarkTheme(bool darkTheme)
        {
            if (Device.RuntimePlatform == Device.iOS)
                DependencyService.Get<IStatusBarStyle>().ChangeTextColor(darkTheme);

            if (darkTheme)
            {
             
                Application.Current.Resources = new DarkTheme();
            }
            else
            {
              

                if (Application.Current.Resources.Source != null &&
                    Application.Current.Resources.Source.OriginalString.ToLower().Contains("light"))
                    return;

                Application.Current.Resources = new LightTheme();
            }
        }

        public override void OnDisappearing()
        {
            UnsubscribeEvents();
        }
    }
}
