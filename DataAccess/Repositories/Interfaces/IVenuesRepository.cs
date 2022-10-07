using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface IVenuesRepository
{
    Task DeleteVenue(int id);
    Task<GetVenuesResponse?> GetVenueById(int id);
    Task<IEnumerable<GetVenuesResponse>> GetVenues();
    Task InsertVenue(VenueModel Venue);
    Task UpdateVenue(VenueModel Venue);
}