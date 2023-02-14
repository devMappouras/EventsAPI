using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class CustomerPurchasesRepository : ICustomerPurchasesRepository
{
    private readonly ISqlDataAccess _db;

    public CustomerPurchasesRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<GetPurchaseIdResponse> InitializePurchase(int CustomerId)
    {
        const int PurchaseStatusId = 1;
            
        var id = await _db.LoadData<int, dynamic>("Purchases_InitializePurchase", new { CustomerId, PurchaseStatusId });
        return new GetPurchaseIdResponse
        {
            PurchaseId = id.FirstOrDefault()
        };
    }

    public async Task CompletePurchase(int PurchaseId)
    {
        const int PurchaseStatusId = 2;
        await _db.SaveData("Purchase_CompletePurchase", new { PurchaseId, PurchaseStatusId });
    }

    public async Task AddPurchasedTickets(IEnumerable<TicketModel> tickets)
    {
        if (!tickets.Any()) throw new Exception("No Tickets Found");

        foreach (var ticket in tickets)
        {
            await _db.SaveData("Tickets_AddTicket", new { ticket.CustomerId, ticket.PurchaseId, ticket.SectionId, ticket.EventProductId });
        }
    }

    public async Task<IEnumerable<GetCustomerTicketsResponse>> GetCustomerTickets(int CustomerId) => 
        await _db.LoadData<GetCustomerTicketsResponse, dynamic>("Tickets_GetTickets", new { CustomerId });
}
