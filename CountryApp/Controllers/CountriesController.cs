using CountryApp.Dtos;
using CountryApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Reflection;

namespace CountryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly CountryService _countryService; // Inject the service
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CountryService> _logger;

        public CountriesController(CountryService countryService, IMemoryCache memoryCache, ILogger<CountryService> logger)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            try
            {
                var cachedCountries = await GetCachedCountriesAsync();
                return Ok(cachedCountries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching countries from API.");
                return StatusCode(500, "An error occurred while fetching countries.");
            }
        }

        private async Task<List<CountryDto>> GetCachedCountriesAsync()
        {
            if (_memoryCache.TryGetValue("AllCountries", out List<CountryDto> cachedCountries))
            {
                return cachedCountries;
            }
            var countriesFromApi = await _countryService.GetAllCountriesAsync();
            _memoryCache.Set("AllCountries", countriesFromApi, TimeSpan.FromHours(1));
            return countriesFromApi;
        }
    }
}
