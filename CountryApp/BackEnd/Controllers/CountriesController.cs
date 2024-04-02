using CountryApp.Constants;
using CountryApp.Dtos;
using CountryApp.Interfaces;
using CountryApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CountryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMemoryCache _memoryCache;

        public CountriesController(ICountryService countryService, IMemoryCache memoryCache)
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

        private async Task<IEnumerable<CountryDto>> GetCachedCountriesAsync()
        {
            if (_memoryCache.TryGetValue(Cache.Key_All, out IEnumerable<CountryDto> cachedCountries))
            {
                return cachedCountries;
            }
            var countriesFromApi = await _countryService.GetAllAsync();
            _memoryCache.Set(Cache.Key_All, countriesFromApi, TimeSpan.FromHours(1));
            return countriesFromApi;
        }
    }
}
