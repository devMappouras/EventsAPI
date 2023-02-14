using DataAccess.Models;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers.CustomerEndpoints;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class CustomerPurchasesController : ControllerBase
{
    private readonly ICustomerPurchasesService _customerPurchasesService;
    public CustomerPurchasesController(ICustomerPurchasesService customerPurchasesService)
    {
        _customerPurchasesService = customerPurchasesService;
    }

    [HttpPost]
    public async Task<IResult> InitializePurchase(int CustomerId)
    {
        try
        {
            return Results.Ok(await _customerPurchasesService.InitializePurchase(CustomerId));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IResult> CompletePurchase(int PurchaseId)
    {
        try
        {
            await _customerPurchasesService.CompletePurchase(PurchaseId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IResult> AddPurchasedTickets(IEnumerable<TicketModel> tickets)
    {
        try
        {
            await _customerPurchasesService.AddPurchasedTickets(tickets);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetCustomerTickets(int CustomerId)
    {
        try
        {
            var result = await _customerPurchasesService.GetCustomerTickets(CustomerId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}