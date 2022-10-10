using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<IEnumerable<GenericIdAndNameModel>> GetCountries();
}