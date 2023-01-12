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

        public async Task<EventModel> GetEventById(int id)
        {
            return await _customerEventsRepository.GetEventById(id);
        }
    }
}