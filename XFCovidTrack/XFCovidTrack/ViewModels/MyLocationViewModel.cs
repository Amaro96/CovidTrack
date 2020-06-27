using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using XFCovidTrack.Interfaces;
using XFCovidTrack.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace XFCovidTrack.ViewModels
{
    public class MyLocationViewModel : BaseViewModel
    {
        private readonly IRestService _Service;
        public Command CloseWhenIsClicked { get; }

        public MyLocationViewModel(IRestService _restService)
        {
            _Service = _restService;
            CloseWhenIsClicked = new Command(async () => await close());
        }

        private bool _ClickedToClose = true;

        public bool clickedBackgroundToClose
        {

            get { return _ClickedToClose; }

            set { SetProperty(ref _ClickedToClose, value); }
        }

        private Countryinfo Countryinfo;

        private string _countryFlag;

        public string CountryFlag
        {

            get { return _countryFlag; }

            set { SetProperty(ref _countryFlag, value); }
        }

        private string date;

        public string DateToday
        {

            get { return date; }

            set { SetProperty(ref date, value); }
        }

        private int _cases;

        public int cases
        {
            get { return _cases; }

            set { SetProperty(ref _cases, value); }
        }

        private int _todayCases;

        public int todayCases
        {
            get { return _todayCases; }

            set { SetProperty(ref _todayCases, value); }
        }

        private int _deaths;

        public int deaths
        {
            get { return _deaths; }

            set { SetProperty(ref _deaths, value); }
        }

        private int _recovered;

        public int recovered
        {
            get { return _recovered; }

            set { SetProperty(ref _recovered, value); }
        }

        private int _active;

        public int active
        {
            get { return _active; }

            set { SetProperty(ref _active, value); }
        }


        public async Task close()
        {
            await PopupNavigation.Instance.PopAsync();
        }


        private async Task GetByCountry(bool isBusyCountries = false)
        {

            IsBusy = true;
            IsBusyCountry = isBusyCountries;
            try
            {
                var permissions = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (permissions != PermissionStatus.Granted)
                {
                    permissions = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }
                if (permissions != PermissionStatus.Granted)
                { return; }

                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    location = await Geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(30)
                        });
                }

                if (location == null)
                {
                    await PopupNavigation.Instance.PopAsync();
                    await App.Current.MainPage.DisplayAlert("Warning", "NO GPS", "OK");
                }
                else
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location);

                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark == null)
                    {
                        
                            var response = await _Service.GetTotalsByCountry("AO");
                            if (response != null)
                            {
                                active = response.active;
                                cases = (int)response.cases;
                                deaths = (int)response.deaths;
                                recovered = (int)response.recovered;
                                todayCases = (int)response.todayCases;
                                CountryFlag = response.countryInfo.flag;
                               
                            }
                        }
                        DateToday = DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("dd/MM/yyyy");
                    }
                
            }
            catch { }
            finally
            {
                IsBusy = false;
                IsBusyCountry = false;
            }
        }

        public async Task GetAll()
        {
            await GetByCountry();
        }
    }
}
