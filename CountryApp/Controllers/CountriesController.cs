using CountryApp.Dtos;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;

        public CountriesController(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            if (!_memoryCache.TryGetValue("AllCountries", out List<CountryDto> cachedCountries))
            {
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetStringAsync("https://restcountries.com/v3.1/all");

                //var countries = JsonSerializer.Deserialize<IEnumerable<CountryDto>>(new StreamReader(response).ReadToEnd());
                //var countries = new JsonSerializer().Deserialize<CountryDto>(response);
                var countries = JsonConvert.DeserializeObject<List<CountryDto>>(response);
                //var countries = await response.Content.ReadAsAsync<List<CountryDto>>();

                _memoryCache.Set("AllCountries", countries, TimeSpan.FromHours(1));
                cachedCountries = (List<CountryDto>)GetMockCountries();
            }

            return Ok(cachedCountries);
        }



        private object? GetMockCountries()
        {
            throw new NotImplementedException();
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
