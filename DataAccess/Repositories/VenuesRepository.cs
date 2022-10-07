using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class VenuesRepository : IVenuesRepository
{
    private readonly ISqlDataAccess _db;

    public VenuesRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<GetVenuesResponse>> GetVenues() => _db.LoadData<GetVenuesResponse, dynamic>("Venues_GetAll", new { });

    public async Task<GetVenuesResponse?> GetVenueById(int venueId)
    {
        var results = await _db.LoadData<GetVenuesResponse, dynamic>("Venues_Get", new { VenueId = venueId });
        return results.FirstOrDefault();
    }

    public Task InsertVenue(VenueModel venue) => _db.SaveData("Venues_Insert", new { venue.Name, venue.Address, venue.Town, venue.CountryId });

    public Task UpdateVenue(VenueModel venue) => _db.SaveData("Venues_Update", venue);

    public Task DeleteVenue(int venueId) => _db.SaveData("Venues_Delete", new { VenueId = venueId });
}
