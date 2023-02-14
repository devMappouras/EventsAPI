using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services
{
    public class CustomerPurchasesService : ICustomerPurchasesService
    {
        private readonly ICustomerPurchasesRepository _customerPurchasesRepository;
        public CustomerPurchasesService(ICustomerPurchasesRepository customerPurchasesRepository)
        {
            _customerPurchasesRepository = customerPurchasesRepository;
        }
        
        public async Task<GetPurchaseIdResponse> InitializePurchase(int CustomerId)
        {
            return await _customerPurchasesRepository.InitializePurchase(CustomerId);
        }

        public async Task CompletePurchase(int PurchaseId)
        {
            await _customerPurchasesRepository.CompletePurchase(PurchaseId);
        }

        public async Task AddPurchasedTickets(IEnumerable<TicketModel> tickets)
        {
            await _customerPurchasesRepository.AddPurchasedTickets(tickets);
        }

        public async Task<IEnumerable<GetCustomerTicketsResponse>> GetCustomerTickets(int CustomerId)
        {
            return await _customerPurchasesRepository.GetCustomerTickets(CustomerId);
        }
    }
}