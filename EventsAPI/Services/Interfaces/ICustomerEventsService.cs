using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces
{
    public interface ICustomerEventsService
    {
        Task<EventModel> GetEventById(int id);

        Task<IEnumerable<GetEventsResponse>> GetHomeScreenEvents(int CustomerId);
    }
}
