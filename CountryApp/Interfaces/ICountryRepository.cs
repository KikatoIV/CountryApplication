using CountryApp.Dtos;

namespace CountryApp.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
    }
}
