using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface IEventsRepository
{
    Task DeleteEvent(int id);
    Task<EventModel?> GetEventById(int id);
    Task<IEnumerable<GetEventsResponse>> GetEvents();
    Task InsertEvent(EventModel Event);
    Task UpdateEvent(EventModel Event);
}