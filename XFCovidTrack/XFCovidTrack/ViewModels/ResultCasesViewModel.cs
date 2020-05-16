using Acr.UserDialogs;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFCovidTrack.Interfaces;
using XFCovidTrack.Models;
using XFCovidTrack.Views;

namespace XFCovidTrack.ViewModels
{
    public class ResultCasesViewModel : BaseViewModel
    {
        private readonly IRestService _service;
        public ICommand refreshCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand SelectionCommand { get; }
        public ObservableCollection<Country> countries { get; set; }

        public ResultCasesViewModel(IRestService restService)
        {
            _service = restService;
            countries = new ObservableCollection<Country>();

            refreshCommand = new Command(async () => await RefreshAsync());
            SearchCommand = new Command(async () => await SearchCountry());
            SelectionCommand = new Command(ItemSelected);
            IsVisible = false;

        }

        private Country _selection;
        public Country Selection
        {
            get { return _selection; }
            set { SetProperty(ref _selection, value); }
        }

        private bool _IsVisible = false;

        private bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                SetProperty(ref _IsVisible, value);
            }
        }

        private bool _IsRefreshing = false;

        private bool IsRefreshing

        {
            get { return _IsRefreshing; }
            set
            {
                SetProperty(ref _IsRefreshing, value);
            }
        }

        async Task RefreshAsync()
        {

            IsRefreshing = true;

            IsVisible = true;

            IsRefreshing = false;
        }
        private int _Cases;

        public int Cases
        {
            get { return _Cases; }
            set { SetProperty(ref _Cases, value); }
        }

        private string _searchText;

        public string searchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        private float _recovered;
        public float recovered
        {
            get { return _recovered; }
            set
            {
                SetProperty(ref _recovered, value);
            }
        }
        private float _deaths;

        public float deaths
        {
            get { return _deaths; }
            set
            {
                SetProperty(ref _deaths, value);
            }
        }

        private string _flag;
        public string flag
        {
            get { return _flag; }
            set
            {
                SetProperty(ref _flag, value);
            }
        }

        private float _cases;
        public float cases
        {
            get { return _cases; }
            set
            {
                SetProperty(ref _cases, value);
            }
        }

        private string _country;
        public string country
        {
            get { return _country; }
            set
            {
                SetProperty(ref _country, value);
            }
        }

        private string _todayCases;
        public string todayCases
        {
            get { return _todayCases; }
            set
            {
                SetProperty(ref _todayCases, value);
            }
        }

        private int _Recovered;
        public int Recovered
        {
            get { return _Recovered; }
            set
            {
                SetProperty(ref _Recovered, value);
            }
        }
        private int _Deaths;

        public int Deaths
        {
            get { return _Deaths; }
            set
            {
                SetProperty(ref _Deaths, value);
            }
        }

        private string _Filter;

        public string Filter
        {
            get { return _Filter; }
            set
            {
                SetProperty(ref _Filter, value);
            }
        }


        private Country Country { get; set; }
        private GlobalCases GlobalCases { get; set; }

        private async void ItemSelected()
        {
            if (Selection != null)
            {
                var country = Selection;
             
                Selection = null;
                await PopupNavigation.Instance.PushAsync(new CountrySelectedPoup(country));
                Filter = string.Empty;
            }
        }

            public async Task GetGlobalTotals(bool isBusyCountry = false)
        {
            IsBusy = true;
            IsBusyCountry = isBusyCountry;

            try
            {
                var response = await _service.GetGlobalTotals();
                if(response != null) { SetCountryCases(response); }             
                else  {App.Current.MainPage.DisplayAlert("Internet", "Your connection is very low to get data", "OK");
                    return;}
            }
            catch { }
            finally
            {
                IsBusy = false;
                IsBusyCountry = false;
            }
        }

        async Task SearchCountry()
        {

        }

        private async Task GetCountry(bool isBusyCountry = false)
        {

            IsBusy = true;
            IsBusyCountry = isBusyCountry;
            try
            {
                var response = await _service.GetCountryMoreCases();
                if (response != null)
                {
                    foreach (var item in response)
                    {
                        //    NÃO SÃO PAÍSES, SÃO NAVIOS DE CRUZEIRO o.O
                        if (item.country.ToLower().Contains("zaandam") ||
                            item.country.ToLower().Contains("diamond princess"))
                            continue;

                        countries.Add(item);

                    }

                }

            }
            catch { }
            finally
            {
                IsBusy = false;
                IsBusyCountry = false;
                UserDialogs.Instance.HideLoading();
            }
        }

        public async Task GetAll()
        {
            await GetGlobalTotals();
            await GetCountry();
            IsVisible = false;
        }
        private void SetCountryCases(GlobalCases response)
        {

            if (response != null)
            {
                GlobalCases = response;

                Cases = response.cases;
                Recovered = response.recovered;
                Deaths = response.deaths;

            }
        }
    }
}
