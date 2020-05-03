using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCovidTrack.Models;

namespace XFCovidTrack.Interfaces
{
   public interface IRestService
    {
        Task<IEnumerable<Country>> GetGlobalCases();
        Task<Country> GetTotalsByCountry(string countryName);
        Task<CountryCases> GetCountryMoreCases();

        Task<GlobalCases> GetGlobalTotals();
    }
}
