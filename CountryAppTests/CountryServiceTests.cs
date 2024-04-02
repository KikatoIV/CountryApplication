using CountryApp.Dtos;
using CountryApp.Interfaces;
using CountryApp.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CountryAppTests
{
    public class CountryServiceTests
    {
        private readonly Mock<ICountryRepository> _repositoryMock;
        private readonly CountryService _countryService;

        public CountryServiceTests()
        {
            _repositoryMock = new Mock<ICountryRepository>();
            _countryService = new CountryService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Countries()
        {
            // Arrange
            var expectedCountries = MockData.GetMockCountries();

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedCountries);

            // Act
            var result = await _countryService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCountries, result);
        }

    }
}
