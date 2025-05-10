using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CountryApi.Controllers;
using CountryApi.Models;
using CountryApi.Services;
using System.Threading.Tasks;
using System.Collections.Generic;


public class CountriesControllerTests
{
    [Fact]
    public async Task GetCountries_ReturnsCountryList()
    {
        var mockService = new Mock<IRestCountriesService>();
        mockService.Setup(s => s.GetAllCountriesAsync())
            .ReturnsAsync(new List<Country>
            {
                new Country { Name = "South Africa", Flag = "https://example.com/flag.png" }
            });

        var controller = new CountriesController(mockService.Object);

        var result = await controller.GetCountries();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var countries = Assert.IsType<List<Country>>(okResult.Value);
        Assert.Single(countries);
        Assert.Equal("South Africa", countries[0].Name);
    }
}
