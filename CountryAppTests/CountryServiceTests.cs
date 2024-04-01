using CountryApp.Dtos;
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
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<IMemoryCache> _memoryCacheMock;
        private readonly Mock<ILogger<CountryService>> _loggerMock;
        private readonly CountryService _countryService;

        public CountryServiceTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _memoryCacheMock = new Mock<IMemoryCache>();
            _loggerMock = new Mock<ILogger<CountryService>>();
            _countryService = new CountryService(_httpClientFactoryMock.Object, _memoryCacheMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnsCountriesFromApi_WhenNotCached()
        {
            // Arrange

            // Act
            var result = await _countryService.GetAllCountriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count); 
        }

        public static class MockMemoryCacheService
        {
            public static IMemoryCache GetMemoryCache(object expectedValue)
            {
                var mockMemoryCache = new Mock<IMemoryCache>();
                mockMemoryCache
                    .Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue))
                    .Returns(true);
                return mockMemoryCache.Object;
            }
        }

        public class TestHttpMessageHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                // Simulate response from the API
                var responseContent = File.ReadAllText("sampleResponse.json");
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(responseContent)
                };

                return await Task.FromResult(response);
            }
        }
    }
}
