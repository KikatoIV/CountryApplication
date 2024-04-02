using CountryApp.Constants;
using CountryApp.Controllers;
using CountryApp.Dtos;
using CountryApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace CountryAppTests
{
    public class CountriesControllerTests
    {
        [Fact]
        public async Task GetAllCountriesAsync_ReturnsOkResult_WithCountries()
        {
            // Arrange
            var mockCountryService = new Mock<ICountryService>();
            var controller = new CountriesController(mockCountryService.Object);

            var countriesFromService = MockData.GetMockCountries();

            mockCountryService.Setup(s => s.GetAllAsync())
                              .ReturnsAsync(countriesFromService);

            // Act
            var result = await controller.GetAllCountriesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCountries = Assert.IsType<List<CountryDto>>(okResult.Value);
            Assert.Equal(countriesFromService, returnedCountries);
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnsInternalServerError_OnException()
        {
            // Arrange
            var mockCountryService = new Mock<ICountryService>();
            var controller = new CountriesController(mockCountryService.Object);

            mockCountryService.Setup(s => s.GetAllAsync())
                              .ThrowsAsync(new Exception("Simulated error"));

            // Act
            var result = await controller.GetAllCountriesAsync();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}