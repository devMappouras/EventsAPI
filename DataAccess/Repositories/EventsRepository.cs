using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Data;

public class EventsRepository : IEventsRepository
{
    private readonly ISqlDataAccess _db;

    public EventsRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<EventModel>> GetEvents() => await _db.LoadData<EventModel, dynamic>("Events_GetAll", new {} );

    public async Task<EventModel?> GetEventById(int EventId)
    {
        var results = await _db.LoadData<EventModel, dynamic>("Events_Get", new { EventId = EventId });
        return results.FirstOrDefault();
    }

    public Task InsertEvent(EventModel Event) => _db.SaveData("Events_Insert", 
        new { 
            Event.EventTitle, 
            Event.EventDescription, 
            Event.EventDateTime, 
            Event.BannerImage, 
            Event.CollectionId, 
            Event.OrganiserId, 
            Event.VenueId 
        });

    public Task UpdateEvent(EventModel Event) => _db.SaveData("Events_Update", Event);

    public Task DeleteEvent(int EventId) => _db.SaveData("Events_Delete", new { EventId = EventId });
}
