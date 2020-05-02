using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFCovidTrack
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

     
        private async void btnTest_Clicked(object sender, EventArgs e)
        {

            try
            {
                var permissions = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if(permissions != PermissionStatus.Granted)
                {
                    permissions = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }
                if(permissions != PermissionStatus.Granted)
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
                        lblTest.Text = "NO GPS";
                    else
                        lblTest.Text = $"{location.Latitude} {location.Longitude}";


                var placemarks = await Geocoding.GetPlacemarksAsync(location);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    var texto = "Localização: " + location.Latitude + " Lon: " + location.Longitude +
                        " ISO: " + placemark.CountryCode + " País: " + placemark.CountryName;
                    await DisplayAlert("Localização", texto, "OK");
                    lblTest.Text = texto;
                }
                //{

                //}


            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Something is wrong: {ex.Message }");
            }


        }
    }
}
