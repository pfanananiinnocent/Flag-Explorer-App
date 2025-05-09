using Microsoft.AspNetCore.Mvc;
using CountryApi.Models;
using CountryApi.Services;

namespace CountryApi.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        private readonly IRestCountriesService _service;

        public CountriesController(IRestCountriesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _service.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CountryDetails>> GetCountryByName(string name)
        {
            var country = await _service.GetCountryByNameAsync(name);
            if (country == null) return NotFound();

            return Ok(country);
        }
    }
}
