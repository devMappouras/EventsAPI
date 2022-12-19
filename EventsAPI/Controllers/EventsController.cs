using DataAccess.Models;
using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;
    private readonly IVenuesService _venuesService;
    private readonly ICollectionsService _collectionsService;
    private readonly ICategoriesService _categoriesService;

    public EventsController(IEventsService eventsService, IVenuesService venuesService, ICollectionsService collectionsService, ICategoriesService categoriesService)
    {
        _eventsService = eventsService;
        _venuesService = venuesService;
        _collectionsService = collectionsService;
        _categoriesService = categoriesService;
    }

    [HttpGet, Authorize]
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

    [HttpPost, Authorize]
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

    [HttpPut, Authorize]
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

    [HttpPost, Authorize]
    public async Task<IResult> DeleteEvent([FromBody] int EventId)
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
            var categories = await _categoriesService.GetCategories();

            return Results.Ok(new GetVenuesAndCollections(venues.ToList(), collections.ToList(), categories.ToList()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}