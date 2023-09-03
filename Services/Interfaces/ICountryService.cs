using Net_AI_UseCase1.Models;

namespace Net_AI_UseCase1.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountries(string p1 = "", int p2 = 0, string p3 = "");
    }
}
