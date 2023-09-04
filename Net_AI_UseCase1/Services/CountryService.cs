using Net_AI_UseCase1.Models;
using Net_AI_UseCase1.Services.Interfaces;
using Newtonsoft.Json;

namespace Net_AI_UseCase1.Services
{
    public class CountryService : ICountryService
    {
        public async Task<IEnumerable<Country>> GetCountries(string filterCountryName, int filterPopulation, int rowCount, string order)
        {
            var countries = await GetAllCountriesFromApi();
            countries = FilterByCountryName(countries, filterCountryName);
            countries = FilterByPopulation(countries, filterPopulation);
            countries = SortByCountryName(countries, order);
            countries = GetFirstNRecords(countries, rowCount);

            return countries;
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

        private static IEnumerable<Country> FilterByCountryName(IEnumerable<Country> countries, string countryName)
        {
            return string.IsNullOrEmpty(countryName) ? 
                countries :
                countries.Where(x => x.Name.Common.ToLower().Contains(countryName.ToLower()));
        }

        private static IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int population)
        {
            const int milion = 1000000;
            return population < 0 ?
                countries :
                countries.Where(x => x.Population < population * milion);
        }

        private static IEnumerable<Country> SortByCountryName(IEnumerable<Country> countries, string order = "ascend")
        {
            return order == "descend" ? 
                countries.OrderByDescending(x => x.Name.Common) : 
                countries.OrderBy(x => x.Name.Common);
        }

        private static IEnumerable<Country> GetFirstNRecords(IEnumerable<Country> countries, int number) 
        {
            return number < 0 ?
                countries :
                countries.Take(number);
        }
    }
}
