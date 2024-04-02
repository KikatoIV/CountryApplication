using System.Text.Json;
using CountryApp.Dtos;
using CountryApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CountryApp.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;

        public CountryService(ICountryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync(); ;
        }
    }
}
