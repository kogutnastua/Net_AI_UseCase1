using Microsoft.OpenApi.Services;
using Net_AI_UseCase1.Models;
using Net_AI_UseCase1.Services.Interfaces;
using Newtonsoft.Json;
using System;
using static System.Net.WebRequestMethods;

namespace Net_AI_UseCase1.Services
{
    public class CountryService : ICountryService
    {
        public async Task<IEnumerable<Country>> GetCountries(string p1 = "", int p2 = 0, string p3 = "")
        {
            return await GetAllCountriesFromApi();
        }

        private static async Task<IEnumerable<Country>> GetAllCountriesFromApi()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://restcountries.com/v3.1/all");

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Country>>(result!)!;
            }
            else
            {
                throw new BadHttpRequestException("Error selecting countries from open API.");
            }
        }
    }
}
