using EventsAPI.Models;
using System.Collections.Generic;

namespace EventsAPI.Services.Interfaces
{
    public interface IVenuesService
    {
        Task InsertVenue(VenueEntity venue);

        Task UpdateVenue(VenueEntity venue);

        Task DeleteVenue(int id);

        Task<VenueEntity> GetVenueById(int id);

        Task<IEnumerable<VenueEntity>> GetVenues();
    }
}
