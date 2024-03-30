using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using CountryApp.Dtos;
using CountryApp.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CountryApp.Services
{
    public class CountryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CountryService> _logger;

        public CountryService(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache, ILogger<CountryService> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<CountryDto>> GetAllCountriesAsync()
        {
            if (!_memoryCache.TryGetValue("AllCountries", out List<CountryDto> cachedCountries))
            {
                try
                {
                    var httpClient = _httpClientFactory.CreateClient();
                    var responseContent = await httpClient.GetStringAsync("https://restcountries.com/v3.1/all");

                    // Deserialize the response into a list of CountryDto
                    var countriesData = JsonSerializer.Deserialize<List<CountryBase>>(responseContent);

                    foreach (var countryData in countriesData)
                    {
                        var country = new CountryDto
                        {
                            Name = countryData.name.common,
                            Capital = countryData.capital,
                            Currencies = 

                        };

                        cachedCountries.Add(country);
                    }



                    // Cache the data for 1 hour
                    _memoryCache.Set("AllCountries", cachedCountries, TimeSpan.FromHours(1));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching countries from API.");
                }
            }

            return cachedCountries;
        }
    }
}
