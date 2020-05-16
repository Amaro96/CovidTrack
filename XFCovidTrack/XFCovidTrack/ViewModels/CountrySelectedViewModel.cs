using System;
using System.Collections.Generic;
using System.Text;

namespace XFCovidTrack.ViewModels
{
    public class CountrySelectedViewModel : BaseViewModel
    {
        public CountrySelectedViewModel()
        {

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
    }
}
