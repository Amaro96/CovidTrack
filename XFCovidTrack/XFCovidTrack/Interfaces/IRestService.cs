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
        Task<Country> GetTotalsByCountry(string countryISO);
        Task<IEnumerable<Country>> GetCountryMoreCases();

        Task<GlobalCases> GetGlobalTotals();
    }
}
