using Microsoft.AspNetCore.Mvc;
using SectionsAPI.Services.Interfaces;
using DataAccess.Models;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class SectionsController : ControllerBase
{
    private readonly ISectionsService _SectionsService;

    public SectionsController(ISectionsService SectionsService)
    {
        _SectionsService = SectionsService;
    }

    [HttpGet]
    public async Task<IResult> GetSections(int VenueId)
    {
        try
        {
            return Results.Ok(await _SectionsService.GetSections(VenueId));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetSectionById([FromBody] int SectionId)
    {
        try
        {
            var result = await _SectionsService.GetSectionById(SectionId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> InsertSection(SectionModel Section)
    {
        try
        {
            await _SectionsService.InsertSection(Section);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdateSection(SectionModel Section)
    {
        try
        {
            await _SectionsService.UpdateSection(Section);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> DeleteSection([FromBody] int SectionId)
    {
        try
        {
            await _SectionsService.DeleteSection(SectionId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}