using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class EventsRepository : IEventsRepository
{
    private readonly ISqlDataAccess _db;

    public EventsRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetEventsResponse>> GetEvents() => 
        await _db.LoadData<GetEventsResponse, dynamic>("Events_GetAll", new { OrganiserId = 1});

    public async Task<EventModel?> GetEventById(int EventId)
    {
        var results = await _db.LoadData<EventModel, dynamic>("Events_Get", new { EventId });
        return results.FirstOrDefault();
    }

    public Task InsertEvent(EventModel Event) => _db.SaveData("Events_Insert",
        new
        {
            Event.EventTitle,
            Event.EventDescription,
            Event.EventDateTime,
            Event.BannerImage,
            Event.CollectionId,
            Event.OrganiserId,
            Event.VenueId
        });

    public Task UpdateEvent(EventModel Event) => 
        _db.SaveData("Events_Update", Event);

    public Task DeleteEvent(int EventId) => 
        _db.SaveData("Events_Delete", new { EventId });
}
