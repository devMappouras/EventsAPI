using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class VenuesController : ControllerBase
{
    private readonly IVenuesService _venuesService;

    public VenuesController(IVenuesService venuesService)
    {
        _venuesService = venuesService;
    }

    [HttpGet(nameof(GetVenues))]
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

    [HttpGet(nameof(GetVenueById))]
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

    [HttpPost(nameof(InsertVenue))]
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

    [HttpPut(nameof(UpdateVenue))]
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

    [HttpDelete(nameof(DeleteVenue))]
    public async Task<IResult> DeleteVenue(int venueId)
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