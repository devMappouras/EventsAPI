using DataAccess.Models;
using DataAccess.Models.Responses;

namespace EventsAPI.Services.Interfaces;

public interface ICustomerPurchasesService
{
    Task<GetPurchaseIdResponse> InitializePurchase(int CustomerId);
    Task CompletePurchase(int PurchaseId);
    Task AddPurchasedTickets(IEnumerable<TicketModel> tickets);
    Task<IEnumerable<GetCustomerTicketsResponse>> GetCustomerTickets(int CustomerId); 
}