using CountryApi.Models;
using System.Net.Http.Json;

namespace CountryApi.Services
{
    public class RestCountriesService
    {
        private readonly HttpClient _httpClient;

        public RestCountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1/");
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<dynamic>>("all");

            return response.Select(c => new Country
            {
                Name = c.name.common,
                Flag = c.flags.png
            });
        }

        public async Task<CountryDetails?> GetCountryByNameAsync(string name)
        {
            var response = await _httpClient.GetFromJsonAsync<List<dynamic>>($"name/{name}");

            var country = response.FirstOrDefault();
            if (country == null) return null;

            return new CountryDetails
            {
                Name = country.name.common,
                Capital = country.capital != null ? country.capital[0] : "N/A",
                Population = country.population,
                Flag = country.flags.png
            };
        }
    }
}
