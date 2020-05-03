using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFCovidTrack.ViewModels
{
    public class TesteViewModel : BaseViewModel
    {
        public Command ChangeAppThemeCommand { get; }

        public TesteViewModel()
        {
            ChangeAppThemeCommand = new Command(async () => await ExecuteChangeAppThemeCommand());
            CheckAppTheme();
        }
        private bool _appDarkTheme;
        public bool AppDarkTheme
        {
            get { return _appDarkTheme; }
            set
            {
                SetProperty(ref _appDarkTheme, value);
            }
        }

        void CheckAppTheme()
        {
            AppDarkTheme = Preferences.Get("appDarkTheme", false);
        }

        private async Task ExecuteChangeAppThemeCommand()
        {
            Preferences.Set("appDarkTheme", AppDarkTheme);
            MessagingCenter.Send(this, "changeAppTheme", AppDarkTheme);
            
        }
    }
}
