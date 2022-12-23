using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services
{
    public class CustomerEventsService : ICustomerEventsService
    {
        private readonly IEventsRepository _EventsRepository;

        public CustomerEventsService(IEventsRepository EventsRepository)
        {
            _EventsRepository = EventsRepository;
        }

        public async Task<IEnumerable<GetEventsResponse>> GetHomeScreenEvents(int CustomerId)
        {
            return await _EventsRepository.GetHomeScreenEvents(CustomerId);
        }

        public async Task<EventModel> GetEventById(int id)
        {
            return await _EventsRepository.GetEventById(id);
        }
    }
}