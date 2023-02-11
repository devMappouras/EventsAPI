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

    public CustomerEventsController(ICustomerEventsService customerEventsService, IVenuesService venuesService)
    {
        _customerEventsService = customerEventsService;
        _venuesService = venuesService;
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
    public async Task<IResult> GetExploreEvents(int CustomerId)
    {
        try
        {
            return Results.Ok(await _customerEventsService.GetExploreEvents(CustomerId));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    [HttpGet]
    public async Task<IResult> GetEventProductsForCustomer(int EventId)
    {
        try
        {
            return Results.Ok(await _customerEventsService.GetEventProductsForCustomer(EventId));
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
    public async Task<IResult> GetVenues()
    {
        try
        {
            return Results.Ok(await _venuesService.GetVenues());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}