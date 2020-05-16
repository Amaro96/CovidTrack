using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Models;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountrySelectedPoup : PopupPage
    {
    
        public CountrySelectedPoup(Country country)
        {
            InitializeComponent();
            txtActive.Text = country.active.ToString();
            txtCases.Text = string.Format(country.cases.ToString(), "n2");      
            txtDeaths.Text = country.deaths.ToString();
            txtRecovered.Text = string.Format(country.recovered.ToString(), "n2");
            txttodayDeaths.Text = country.todayDeaths.ToString();
            countryFlag.Source = country.countryInfo.flag;

        }

        private async void close_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}