using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IVenuesRepository
{
    Task DeleteVenue(int id);
    Task<VenueEntity?> GetVenueById(int id);
    Task<IEnumerable<VenueEntity>> GetVenues();
    Task InsertVenue(VenueEntity Venue);
    Task UpdateVenue(VenueEntity Venue);
}