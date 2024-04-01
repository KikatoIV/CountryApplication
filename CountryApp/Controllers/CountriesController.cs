using CountryApp.Dtos;
using CountryApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CountryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly CountryService _countryService; // Inject the service
        private readonly IMemoryCache _memoryCache;

        public CountriesController(CountryService countryService, IMemoryCache memoryCache)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            try
            {
                var cachedCountries = await GetCachedCountriesAsync();
                return Ok(cachedCountries);
            }
            catch
            {
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
