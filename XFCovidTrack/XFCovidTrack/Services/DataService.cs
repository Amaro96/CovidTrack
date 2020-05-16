using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XFCovidTrack.Helpers;
using XFCovidTrack.Interfaces;
using XFCovidTrack.Models;

namespace XFCovidTrack.Services
{
    public class DataService : IRestService
    {
        string Url = string.Empty;
        public async Task<IEnumerable<Country>> GetCountryMoreCases()
        {

            try
            {
                 Url = Constants.URL + "countries?sort=cases";

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(Url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            
                            var lista = JsonConvert.DeserializeObject<IList<Country>>(json);

                            return lista;

                        }

                    }

                    return null;
                }
            }
            catch (HttpRequestException ex)
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

                Url = Constants.URL + "all";
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(Url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            var lista = JsonConvert.DeserializeObject<IList<Country>>(json);

                            return lista;

                        }

                    }

                    return null;
                }
            }
            catch (HttpRequestException ex)
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
                Url = Constants.URL + "all";
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(Url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            var cases = JsonConvert.DeserializeObject<GlobalCases> (json);

                            return cases;

                        }

                    }

                    return null;
                }
            }
            catch (HttpRequestException ex)
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

        public async Task<Country> GetTotalsByCountry(string countryISO)
        {
            await Task.Delay(2000);

            try
            {

                Url = Constants.URL + $"countries/{countryISO}";
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(Url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            var Countrycases = JsonConvert.DeserializeObject<Country>(json);

                            return Countrycases;

                        }
                    }

                    return null;
                }
         
            }
            catch (HttpRequestException ex)
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
