using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

public class CountriesService : ICountriesService
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesService(ICountriesRepository CountriesRepository)
    {
        _countriesRepository = CountriesRepository;
    }

    public async Task<IEnumerable<GenericIdAndNameModel>> GetCountries()
    {
        return await _countriesRepository.GetCountries();
    }
}