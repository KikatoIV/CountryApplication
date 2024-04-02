using CountryApp.Dtos;

namespace CountryApp.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllAsync();
    }
}
