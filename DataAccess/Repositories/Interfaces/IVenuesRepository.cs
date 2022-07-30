using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IVenuesRepository
{
    Task DeleteVenue(int id);
    Task<VenueModel?> GetVenueById(int id);
    Task<IEnumerable<VenueModel>> GetVenues();
    Task InsertVenue(VenueModel Venue);
    Task UpdateVenue(VenueModel Venue);
}