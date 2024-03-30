using CountryApp.Controllers;
using CountryApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace CountryAppTests
{
    public class CountriesControllerTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly Mock<IMemoryCache> _mockMemoryCache;
        private readonly CountriesController _controller;

        public CountriesControllerTests()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockMemoryCache = new Mock<IMemoryCache>();
        }
    }

}