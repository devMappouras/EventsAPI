using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services
{
    public class VenuesService : IVenuesService
    {
        private readonly IVenuesRepository _venuesRepository;

        public VenuesService(IVenuesRepository venuesRepository)
        {
            _venuesRepository = venuesRepository;
        }

        public async Task<IEnumerable<VenueModel>> GetVenues()
        {
            return await _venuesRepository.GetVenues();
        }

        public async Task<VenueModel> GetVenueById(int id)
        {
            return await _venuesRepository.GetVenueById(id);
        }

        public async Task InsertVenue(VenueModel venue)
        {

            await _venuesRepository.InsertVenue(venue);
        }

        public async Task UpdateVenue(VenueModel venue)
        {
            await _venuesRepository.UpdateVenue(venue);
        }

        public async Task DeleteVenue(int venuesId)
        {
            await _venuesRepository.DeleteVenue(venuesId);
        }
    }
}