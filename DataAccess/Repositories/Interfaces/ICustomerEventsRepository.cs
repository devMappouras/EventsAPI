using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ICustomerEventsRepository
{
    Task<EventModel?> GetEventById(int id);
    Task<IEnumerable<GetEventsResponse>> GetHomeScreenEvents(int OrganiserId);

    Task<IEnumerable<GetEventsResponse>> GetExploreEvents(int OrganiserId);
}