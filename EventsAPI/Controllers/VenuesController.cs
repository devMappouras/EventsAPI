using DataAccess.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class VenuesController : ControllerBase
{
    private readonly IVenuesService _venuesService;

    public VenuesController(IVenuesService venuesService)
    {
        _venuesService = venuesService;
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

    [HttpGet]
    public async Task<IResult> GetVenueById(int venueId)
    {
        try
        {
            var result = await _venuesService.GetVenueById(venueId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost, Authorize]
    public async Task<IResult> InsertVenue(VenueModel venue)
    {
        try
        {
            await _venuesService.InsertVenue(venue);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut, Authorize]
    public async Task<IResult> UpdateVenue(VenueModel venue)
    {
        try
        {
            await _venuesService.UpdateVenue(venue);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost, Authorize]
    public async Task<IResult> DeleteVenue([FromBody] int venueId)
    {
        try
        {
            await _venuesService.DeleteVenue(venueId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}