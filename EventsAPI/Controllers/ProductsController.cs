using DataAccess.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsAPI/[controller]/[action]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public async Task<IResult> GetProducts()
    {
        try
        {
            return Results.Ok(await _productsService.GetProducts());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetProductById(int ProductId)
    {
        try
        {
            var result = await _productsService.GetProductById(ProductId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> InsertProduct(ProductModel Product)
    {
        try
        {
            await _productsService.InsertProduct(Product);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdateProduct(ProductModel Product)
    {
        try
        {
            await _productsService.UpdateProduct(Product);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> DeleteProduct([FromBody] int ProductId)
    {
        try
        {
            await _productsService.DeleteProduct(ProductId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    /*[HttpGet]
    public async Task<IResult> GetVenuesAndCollections()
    {
        try
        {
            var venues = await _venuesService.GetVenues();
            var collections = await _collectionsService.GetCollections();

            return Results.Ok(new GetVenuesAndCollections(venues.ToList(), collections.ToList()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }*/
}