using DataAccess.Models;
using EventsAPI.Services;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrganisersController : ControllerBase
{
    private readonly IOrganisersService _organisersService;

    public OrganisersController(IOrganisersService OrganisersService)
    {
        _organisersService = OrganisersService;
    }

    [HttpGet]
    public async Task<IResult> GetOrganisers()
    {
        try
        {
            return Results.Ok(await _organisersService.GetOrganisers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetOrganiserById(int OrganiserId)
    {
        try
        {
            var result = await _organisersService.GetOrganiserById(OrganiserId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> InsertOrganiser(OrganiserModel Organiser)
    {
        try
        {
            await _organisersService.InsertOrganiser(Organiser);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdateOrganiser(OrganiserModel Organiser)
    {
        try
        {
            await _organisersService.UpdateOrganiser(Organiser);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> DeleteOrganiser(int OrganiserId)
    {
        try
        {
            await _organisersService.DeleteOrganiser(OrganiserId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
