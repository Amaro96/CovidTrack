using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XFCovidTrack.Models;

namespace XFCovidTrack.ViewModels
{
   public class ChartMV
    {
        public ObservableCollection<GraphyCountry> graphyCountries { get; set; }

        public ChartMV()
        {
            graphyCountries = new ObservableCollection<GraphyCountry>()
            {
                new GraphyCountry{continent= "AFRICA", qtd= 20},
                new GraphyCountry{continent= "AFR", qtd= 202},
                new GraphyCountry{continent= "AF", qtd= 120}
            };

            
        }

        public void Filter()
        {

        }
    }
}
