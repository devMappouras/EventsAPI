using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly ISqlDataAccess _db;

    public CustomersRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetCustomersResponse>> GetCustomers() => await _db.LoadData<GetCustomersResponse, dynamic>("Customers_GetAll", new { });

    public async Task<CustomerModel?> GetCustomerById(int CustomerId)
    {
        var results = await _db.LoadData<CustomerModel, dynamic>("Customers_Get", new { CustomerId = CustomerId });
        return results.FirstOrDefault();
    }

    public Task RegisterCustomer(CustomerModel Customer) => _db.SaveData("Customers_Insert",
        new
        {
            Customer.Username,
            Customer.Password,
            Customer.PasswordSalt,
            Customer.FirstName,
            Customer.LastName,
            Customer.Email,
            Customer.CountryId,
        });

    public async Task<CustomerModel> GetCustomerInfoByUsername(string Username)
    {
        var results = await _db.LoadData<CustomerModel, dynamic>("Customers_GetInfoForValidation", new { Username });
        return results.FirstOrDefault();
    }


    public Task UpdateCustomer(CustomerModel Customer) => _db.SaveData("Customers_Update", Customer);

    public Task DeleteCustomer(int CustomerId) => _db.SaveData("Customers_Delete", new { CustomerId });
}
