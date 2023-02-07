using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class CustomerEventsRepository : ICustomerEventsRepository
{
    private readonly ISqlDataAccess _db;

    public CustomerEventsRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetEventsResponse>> GetHomeScreenEvents(int CustomerId) => 
        await _db.LoadData<GetEventsResponse, dynamic>("Events_Customer_GetHomeScreenEvents", new { CustomerId });    
    
    public async Task<IEnumerable<GetEventsResponse>> GetExploreEvents(int CustomerId) => 
        await _db.LoadData<GetEventsResponse, dynamic>("Events_Customer_GetExploreEvents", new { CustomerId });

    public async Task<EventModel?> GetEventById(int EventId)
    {
        var results = await _db.LoadData<EventModel, dynamic>("Events_Get", new { EventId });
        return results.FirstOrDefault();
    }
}
