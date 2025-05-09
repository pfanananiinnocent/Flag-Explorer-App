using CountryApi.Models;
using System.Net.Http.Json;

namespace CountryApi.Services
{
    public class RestCountriesService : IRestCountriesService
    {
        private readonly HttpClient _httpClient;

        public RestCountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1/");
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<RestCountryDto>>("all");
            if (response == null)
                return Enumerable.Empty<Country>();

            return response.Select(c => new Country
            {
                Name = c.Name.Common,
                Flag = c.Flags.Png
            });
        }

        public async Task<CountryDetails?> GetCountryByNameAsync(string name)
        {
            var response = await _httpClient.GetFromJsonAsync<List<RestCountryDto>>($"name/{name}");
            var country = response?.FirstOrDefault();
            if (country == null) return null;

            return new CountryDetails
            {
                Name = country.Name.Common,
                Capital = country.Capital?.FirstOrDefault() ?? "N/A",
                Population = country.Population,
                Flag = country.Flags.Png
            };
        }
    }
}
