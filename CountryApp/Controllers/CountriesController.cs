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

        public CountriesController(CountryService countryService, IMemoryCache memoryCache)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            if (!_memoryCache.TryGetValue("AllCountries", out List<CountryDto> cachedCountries))
            {
                // Use the service to fetch countries
                cachedCountries = await _countryService.GetAllCountriesAsync();

                // Cache the data for 1 hour
                _memoryCache.Set("AllCountries", cachedCountries, TimeSpan.FromHours(1));
            }

            return Ok(cachedCountries);
        }

        //    [HttpGet("{countryCode}")]
        //    public async Task<IActionResult> GetCountryDetailsAsync(string countryCode)
        //    {
        //        // Check if data is already cached
        //        if (!_memoryCache.TryGetValue(countryCode, out CountryDto cachedCountry))
        //        {
        //            // Fetch data for the specific country
        //            // (similar to the above approach)

        //            // Cache the data
        //            _memoryCache.Set(countryCode, countryDetails, TimeSpan.FromHours(1));
        //            cachedCountry = countryDetails;
        //        }

        //        return Ok(cachedCountry);
        //    }
    }
}
