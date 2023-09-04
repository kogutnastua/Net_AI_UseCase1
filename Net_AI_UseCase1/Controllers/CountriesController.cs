using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_AI_UseCase1.Models;
using Net_AI_UseCase1.Services.Interfaces;

namespace Net_AI_UseCase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountries(
            string filterCountryName = "",
            int filterPopulation = -1,
            int rowCount = -1,
            string order = "ascend")
        {
            return await _countryService.GetCountries(filterCountryName, filterPopulation, rowCount, order);
        }
    }
}
