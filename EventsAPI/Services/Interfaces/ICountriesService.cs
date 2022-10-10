using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces;

public interface ICountriesService
{
    Task<IEnumerable<GenericIdAndNameModel>> GetCountries();
}