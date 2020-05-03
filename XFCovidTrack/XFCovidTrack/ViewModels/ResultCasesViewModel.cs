using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCovidTrack.Interfaces;
using XFCovidTrack.Models;

namespace XFCovidTrack.ViewModels
{
   public class ResultCasesViewModel : BaseViewModel
    {
        private readonly IRestService _service;
        public ResultCasesViewModel(IRestService restService) {
            _service = restService;
        }

        private int _Cases;

        public int Cases
        { get { return _Cases; }
          set { SetProperty(ref _Cases, value); } 
        }

        private int _recovered;
        public int recovered {
            get {return _recovered; }
            set {SetProperty(ref _recovered,value);
            }
        }
        private int _deaths;

        public int deaths
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

        private int _cases;
        public int cases
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



        private CountryCases CountryCases { get; set; }
        private Country Country { get; set; }
        private GlobalCases GlobalCases { get; set; }

        public async Task GetGlobalTotals(bool isBusyCountry = false)
        {
            IsBusy = true;
            IsBusyCountry = isBusyCountry;

            try
            {
             
                    var response = await _service.GetGlobalTotals();
                   SetCountryCases(response);
          
            }
            catch { }
            finally
            {
                IsBusy = false;
                IsBusyCountry = false;
            }
        }

        private async Task GetCountry() 
        {
            try
            {
                UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Gradient);
                var response = await _service.GetGlobalCases();
                if (response != null)
                {
                    foreach (var item in response)
                    {
                        //NÃO SÃO PAÍSES, SÃO NAVIOS DE CRUZEIRO o.O
                        if (item.country.ToLower().Contains("zaandam") ||
                            item.country.ToLower().Contains("diamond princess"))
                            continue;
                    }
                }
                UserDialogs.Instance.HideLoading();
            }
            catch { }
        }

        public async Task GetAll()
        {
            await GetGlobalTotals();
        }
        private void SetCountryCases(GlobalCases response)
        {
            if(response != null)
            {
                GlobalCases = response;

                Cases = response.cases;
                Recovered = response.recovered;
                Deaths = response.deaths;

            }
        }
    }
}
