using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCovidTrack.Helpers;
using XFCovidTrack.Interfaces;
using XFCovidTrack.Models;

namespace XFCovidTrack.Services
{
    public class RestService : IRestService
    {
        public async Task<CountryCases> GetCountryMoreCases()
        {
            await Task.Delay(2000);

            try
            {
                var response = await Constants.URL
                    .AppendPathSegment("countries?sort=cases")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<CountryCases>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }

        public async Task<IEnumerable<Country>> GetGlobalCases()
        {
            await Task.Delay(2000);

            try
            {
                var response = await Constants.URL
                    .AppendPathSegment("all")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<IList<Country>>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }

        public async Task<GlobalCases> GetGlobalTotals()
        {
            await Task.Delay(2000);

            try
            {
                var response = await Constants.URL
                    .AppendPathSegment("all")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<GlobalCases>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }

        public async Task<Country> GetTotalsByCountry(string countryName)
        {
            await Task.Delay(2000);

            try
            {
                var response = await Constants.URL
                    .AppendPathSegment("countries/"+countryName)
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<Country>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }

     
    }
}
