using CountryApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CountryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            try
            {
                var response = await _countryService.GetAllAsync();
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
