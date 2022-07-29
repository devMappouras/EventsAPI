using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Data;

public class VenuesRepository : IVenuesRepository
{
    private readonly ISqlDataAccess _db;

    public VenuesRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<VenueEntity>> GetVenues() => _db.LoadData<VenueEntity, dynamic>("Venues_GetAll", new {} );

    public async Task<VenueEntity?> GetVenueById(int venueId)
    {
        var results = await _db.LoadData<VenueEntity, dynamic>("Venues_Get", new { VenueId = venueId });
        return results.FirstOrDefault();
    }

    public Task InsertVenue(VenueEntity venue) => _db.SaveData("Venues_Insert", new { venue.Name, venue.Location });

    public Task UpdateVenue(VenueEntity venue) => _db.SaveData("Venues_Update", venue);

    public Task DeleteVenue(int venueId) => _db.SaveData("Venues_Delete", new { VenueId = venueId });
}
