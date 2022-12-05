using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ICustomersRepository
{
    Task DeleteCustomer(int id);
    Task<CustomerModel?> GetCustomerById(int id);
    Task<IEnumerable<GetCustomersResponse>> GetCustomers();
    Task RegisterCustomer(CustomerModel Customer);
    Task UpdateCustomer(CustomerModel Customer);
    Task<CustomerModel> GetCustomerInfoByUsername(string username);
}