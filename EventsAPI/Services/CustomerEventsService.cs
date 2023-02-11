using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services
{
    public class CustomerEventsService : ICustomerEventsService
    {
        private readonly ICustomerEventsRepository _customerEventsRepository;

        public CustomerEventsService(ICustomerEventsRepository customerEventsRepository)
        {
            _customerEventsRepository = customerEventsRepository;
        }

        public async Task<IEnumerable<GetEventsResponse>> GetHomeScreenEvents(int CustomerId)
        {
            return await _customerEventsRepository.GetHomeScreenEvents(CustomerId);
        }        
        
        public async Task<IEnumerable<GetEventsResponse>> GetExploreEvents(int CustomerId)
        {
            return await _customerEventsRepository.GetExploreEvents(CustomerId);
        }

        public async Task<IEnumerable<GetEventProductsForCustomerResponse>> GetEventProductsForCustomer(int EventId)
        {
            return await _customerEventsRepository.GetEventProductsForCustomer(EventId);
        }

        public async Task<EventModel> GetEventById(int id)
        {
            return await _customerEventsRepository.GetEventById(id);
        }
    }
}