using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _EventsRepository;
        private readonly IUserService _userService;

        public EventsService(IEventsRepository EventsRepository, IUserService userService)
        {
            _EventsRepository = EventsRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<GetEventsResponse>> GetEvents()
        {
            return await _EventsRepository.GetEvents(_userService.GetLoggedInOrganiserId());
        }

        public async Task<EventModel> GetEventById(int id)
        {
            return await _EventsRepository.GetEventById(id);
        }

        public async Task InsertEvent(EventModel Event)
        {

            await _EventsRepository.InsertEvent(Event);
        }

        public async Task UpdateEvent(EventModel Event)
        {
            await _EventsRepository.UpdateEvent(Event);
        }

        public async Task DeleteEvent(int EventsId)
        {
            await _EventsRepository.DeleteEvent(EventsId);
        }
    }
}