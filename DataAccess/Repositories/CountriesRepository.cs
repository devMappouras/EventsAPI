using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class CountriesRepository : ICountriesRepository
{
    private readonly ISqlDataAccess _db;
    
    public CountriesRepository(ISqlDataAccess db) { _db = db; }

    public async Task<IEnumerable<GenericIdAndNameModel>> GetCountries() => await _db.LoadData<GenericIdAndNameModel, dynamic>("Countries_GetAll", new { } );
}