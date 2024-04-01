using CountryApp.Controllers;
using CountryApp.Dtos;
using CountryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace CountryAppTests
{
    public class CountriesControllerTests
    {
        private readonly Mock<CountryService> _countryServiceMock;
        private readonly Mock<IMemoryCache> _memoryCacheMock;
        private readonly CountriesController _controller;

        public CountriesControllerTests()
        {
            _countryServiceMock = new Mock<CountryService>();
            _memoryCacheMock = new Mock<IMemoryCache>();
            _controller = new CountriesController(_countryServiceMock.Object, _memoryCacheMock.Object);
        }


    }

}