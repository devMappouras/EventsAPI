using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces
{
    public interface IEventsService
    {
        Task InsertEvent(EventModel Event);

        Task UpdateEvent(EventModel Event);

        Task DeleteEvent(int EventId);

        Task<EventModel> GetEventById(int id);

        Task<IEnumerable<GetEventsResponse>> GetEvents();
    }
}
