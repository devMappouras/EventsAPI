using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IEventsRepository
{
    Task DeleteEvent(int id);
    Task<EventModel?> GetEventById(int id);
    Task<IEnumerable<EventModel>> GetEvents();
    Task InsertEvent(EventModel Event);
    Task UpdateEvent(EventModel Event);
}