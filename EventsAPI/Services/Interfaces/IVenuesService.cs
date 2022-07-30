namespace EventsAPI.Services.Interfaces
{
    public interface IVenuesService
    {
        Task InsertVenue(VenueModel venue);

        Task UpdateVenue(VenueModel venue);

        Task DeleteVenue(int id);

        Task<VenueModel> GetVenueById(int id);

        Task<IEnumerable<VenueModel>> GetVenues();
    }
}
