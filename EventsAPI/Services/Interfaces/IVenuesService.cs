using DataAccess.Models;
using DataAccess.Models.Responses;

namespace EventsAPI.Services.Interfaces;

public interface IVenuesService
{
    Task InsertVenue(VenueModel venue);

    Task UpdateVenue(VenueModel venue);

    Task DeleteVenue(int id);

    Task<GetVenuesResponse> GetVenueById(int id);

    Task<IEnumerable<GetVenuesResponse>> GetVenues();
}