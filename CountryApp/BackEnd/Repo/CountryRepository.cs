using CountryApp.Dtos;
using CountryApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using CountryApp.Constants;
using System.Net.Http;

namespace CountryApp.Repo
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CountryRepository> _logger;

        public CountryRepository(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory, ILogger<CountryRepository> logger)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache)); ;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {

            if (!_memoryCache.TryGetValue(Cache.Key_All, out List<CountryDto> cachedCountries))
            {
                cachedCountries = new List<CountryDto>();

                try
                {
                    var httpClient = _httpClientFactory.CreateClient();
                    var responseContent = await httpClient.GetStringAsync(RestCountries.BaseUrl + RestCountries.All_Endpoint);

                    var countriesData = JsonSerializer.Deserialize<List<BaseCountry>>(responseContent);
                    foreach (var countryData in countriesData)
                    {
                        var country = MapToCountryDto(countryData);
                        cachedCountries.Add(country);
                    }

                    _memoryCache.Set(Cache.Key_All, cachedCountries, TimeSpan.FromHours(1));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching countries from API.");
                }
            }

            return cachedCountries;
        }

        private CountryDto MapToCountryDto(BaseCountry countryData)
        {
            var countryDto = new CountryDto
            {
                Name = countryData.name?.common ?? "none",
                Capital = countryData.capital ?? new string[0], 
                Population = countryData.population,
                IsoCode = countryData.cca3 ?? "none", 
                flag = countryData.flags?.png ?? "none", 
                Languages = countryData.languages?.Values.ToList() ?? new List<string>(), 
                Currencies = countryData.currencies?.SelectMany(pair => pair.Value
                    .Where(innerPair => !string.IsNullOrEmpty(innerPair.Value) && innerPair.Key == "name")
                    .Select(innerPair => innerPair.Value)).ToList() ?? new List<string>()
            };

            return countryDto;
        }
    }
}
