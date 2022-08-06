using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;

    public EventsController(IEventsService EventsService)
    {
        _eventsService = EventsService;
    }

    [HttpGet(nameof(GetEvents))]
    public async Task<IResult> GetEvents()
    {
        try
        {
            return Results.Ok(await _eventsService.GetEvents());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet(nameof(GetEventById))]
    public async Task<IResult> GetEventById(int EventId)
    {
        try
        {
            var result = await _eventsService.GetEventById(EventId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost(nameof(InsertEvent))]
    public async Task<IResult> InsertEvent(EventModel Event)
    {
        try
        {
            await _eventsService.InsertEvent(Event);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut(nameof(UpdateEvent))]
    public async Task<IResult> UpdateEvent(EventModel Event)
    {
        try
        {
            await _eventsService.UpdateEvent(Event);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpDelete(nameof(DeleteEvent))]
    public async Task<IResult> DeleteEvent(int EventId)
    {
        try
        {
            await _eventsService.DeleteEvent(EventId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}