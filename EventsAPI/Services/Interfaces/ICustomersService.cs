using DataAccess.Models.Responses;
using DataAccess.Models;
using DataAccess.Models.Auth;

namespace EventsAPI.Services.Interfaces;

public interface ICustomersService
{
    Task DeleteCustomer(int CustomerId);
    Task<CustomerModel> GetCustomerById(int id);
    Task<IEnumerable<GetCustomersResponse>> GetCustomers();
    Task RegisterCustomer(CustomerModel Customer);
    Task<LoginCustomerResponse> LoginCustomer(UserDto user);
    Task<LoginCustomerResponse> RefreshToken(UserModel user);
    Task UpdateCustomer(CustomerModel Customer);
}