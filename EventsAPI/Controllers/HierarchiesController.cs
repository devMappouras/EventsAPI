using DataAccess.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class HierarchiesController : ControllerBase
{
    private readonly IHierarchiesService _hierarchiesService;

    public HierarchiesController(IHierarchiesService HierarchiesService)
    {
        _hierarchiesService = HierarchiesService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IResult> GetHierarchies()
    {
        try
        {
            return Results.Ok(await _hierarchiesService.GetHierarchies());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IResult> GetVenueHierarchies(int venueId)
    {
        try
        {
            return Results.Ok(await _hierarchiesService.GetVenueHierarchies(venueId));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}