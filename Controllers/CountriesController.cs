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
        public async Task<IEnumerable<Country>> GetCountries(string p1 = "", int p2 = 0, string p3 = "")
        {
            return await _countryService.GetCountries(p1, p2, p3);
        }
    }
}
