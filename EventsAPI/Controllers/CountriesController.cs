using DataAccess.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class CountriesController : ControllerBase
{
    private readonly ICountriesService _countriesService;

    public CountriesController(ICountriesService CountriesService)
    {
        _countriesService = CountriesService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IResult> GetCountries()
    {
        try
        {
            return Results.Ok(await _countriesService.GetCountries());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}