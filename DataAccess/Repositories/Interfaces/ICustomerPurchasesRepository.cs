using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ICustomerPurchasesRepository
{
    Task<GetPurchaseIdResponse> InitializePurchase(int CustomerId);
    Task CompletePurchase(int PurchaseId);
    Task AddPurchasedTickets(IEnumerable<TicketModel> ticketModel);
    Task<IEnumerable<GetCustomerTicketsResponse>> GetCustomerTickets(int CustomerId); 
}