using CountryApp.Dtos;

namespace CountryApp.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
    }
}
