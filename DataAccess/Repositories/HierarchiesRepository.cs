using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class HierarchiesRepository : IHierarchiesRepository
{
    private readonly ISqlDataAccess _db;

    public HierarchiesRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<GenericIdAndNameModel>> GetHierarchies() => 
        _db.LoadData<GenericIdAndNameModel, dynamic>("Hierarchies_GetAll", new { });
    
    public Task<IEnumerable<GenericIdAndNameModel>> GetVenueHierarchies(int VenueId) => 
        _db.LoadData<GenericIdAndNameModel, dynamic>("Hierarchies_GetAllByVenue", new { VenueId });
}
