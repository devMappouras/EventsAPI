using DataAccess.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class CollectionsController : ControllerBase
{
    private readonly ICollectionsService _CollectionsService;

    public CollectionsController(ICollectionsService CollectionsService)
    {
        _CollectionsService = CollectionsService;
    }

    [HttpGet]
    public async Task<IResult> GetCollections()
    {
        try
        {
            return Results.Ok(await _CollectionsService.GetCollections());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetCollectionById(int CollectionId)
    {
        try
        {
            var result = await _CollectionsService.GetCollectionById(CollectionId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost, Authorize]
    public async Task<IResult> InsertCollection(CollectionModel Collection)
    {
        try
        {
            await _CollectionsService.InsertCollection(Collection);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut, Authorize]
    public async Task<IResult> UpdateCollection(CollectionModel Collection)
    {
        try
        {
            await _CollectionsService.UpdateCollection(Collection);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost, Authorize]
    public async Task<IResult> DeleteCollection(int CollectionId)
    {
        try
        {
            await _CollectionsService.DeleteCollection(CollectionId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}