using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers.CustomerEndpoints;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class CustomerEventsController : ControllerBase
{
    private readonly ICustomerEventsService _customerEventsService;
    private readonly IVenuesService _venuesService;
    private readonly ICollectionsService _collectionsService;
    private readonly ICategoriesService _categoriesService;

    public CustomerEventsController(ICustomerEventsService customerEventsService, IVenuesService venuesService, ICollectionsService collectionsService, ICategoriesService categoriesService)
    {
        _customerEventsService = customerEventsService;
        _venuesService = venuesService;
        _collectionsService = collectionsService;
        _categoriesService = categoriesService;
    }

    [HttpGet]
    public async Task<IResult> GetHomeScreenEvents(int CustomerId)
    {
        try
        {
            return Results.Ok(await _customerEventsService.GetHomeScreenEvents(CustomerId));
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
            var result = await _customerEventsService.GetEventById(EventId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
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