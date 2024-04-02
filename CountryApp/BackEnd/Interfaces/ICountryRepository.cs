using CountryApp.Dtos;

namespace CountryApp.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<CountryDto>> GetAllAsync();
    }
}
