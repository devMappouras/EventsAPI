using DataAccess.Models;
using DataAccess.Models.Responses;
namespace DataAccess.Repositories.Interfaces;

public interface IEventsRepository
{
    Task DeleteEvent(int EventId);
    Task<EventModel?> GetEventById(int id);
    Task<IEnumerable<GetEventsResponse>> GetEvents(int OrganiserId);
    Task InsertEvent(EventModel Event);
    Task UpdateEvent(EventModel Event);
}