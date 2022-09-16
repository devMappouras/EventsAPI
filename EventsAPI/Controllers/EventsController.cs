using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;
    private readonly IVenuesService _venuesService;
    private readonly ICollectionsService _collectionsService;

    public EventsController(IEventsService EventsService, IVenuesService venuesService, ICollectionsService collectionsService)
    {
        _eventsService = EventsService;
        _venuesService = venuesService;
        _collectionsService = collectionsService;
    }

    [HttpGet]
    [AllowAnonymous]
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

    [HttpGet]
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

    [HttpPost]
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

    [HttpPut]
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

    [HttpPost]
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
    
    [HttpGet]
    public async Task<IResult> GetVenuesAndCollections()
    {
        try
        {
            var venues = await _venuesService.GetVenues();
            var collections = await _collectionsService.GetCollections();
                
            var data = new GetVenuesAndCollections();

            if (venues.Any())
                foreach (var venue in venues)
                {
                    data.Venues.Append(new GenericIdAndNameModel { Id = venue.VenueId, Name = venue.Name } );
                }
            
            if (collections.Any())
                foreach (var collection in collections)
                {
                    data.Collections.Append(new GenericIdAndNameModel { Id = collection.CollectionId, Name = collection.CollectionName } );
                }

            return Results.Ok(data);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}