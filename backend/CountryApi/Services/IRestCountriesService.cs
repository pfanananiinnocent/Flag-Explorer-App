using CountryApi.Models;

namespace CountryApi.Services
{
    public interface IRestCountriesService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<CountryDetails?> GetCountryByNameAsync(string name);
    }
}
