using System.Text.Json;
using CountryApp.Dtos;
using Microsoft.Extensions.Caching.Memory;

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
                cachedCountries = new List<CountryDto>();

                try
                {
                    var httpClient = _httpClientFactory.CreateClient();
                    var responseContent = await httpClient.GetStringAsync("https://restcountries.com/v3.1/all");

                    var countriesData = JsonSerializer.Deserialize<IEnumerable<Root>>(responseContent);
                    foreach (var countryData in countriesData)
                    {
                        var country = new CountryDto
                        {
                            Name = countryData.name.common,
                            Capital = countryData.capital,
                            Population = countryData.population,
                            IsoCode = countryData.cca3,
                            flag = countryData.flags.png,
                            Languages = countryData.languages.Values.ToArray(),
                            Currencies = countryData.currencies
                                .SelectMany(pair => pair.Value.Where(innerPair => innerPair.Key == "name").Select(innerPair => innerPair.Value))
                                .ToArray()
                        };

                        cachedCountries.Add(country);
                    }

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
