using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.Models.Auth;
using Microsoft.IdentityModel.Tokens;

namespace EventsAPI.Services;

public class CustomersService : ICustomersService
{
    private readonly ICustomersRepository _customersRepository;
    private readonly IConfiguration _configuration;

    public CustomersService(ICustomersRepository CustomersRepository, IConfiguration configuration)
    {
        _customersRepository = CustomersRepository;
        _configuration = configuration;
    }

    public async Task<IEnumerable<GetCustomersResponse>> GetCustomers()
    {
        return await _customersRepository.GetCustomers();
    }

    public async Task<CustomerModel> GetCustomerById(int id)
    {
        return await _customersRepository.GetCustomerById(id);
    }

    public async Task RegisterCustomer(CustomerModel Customer)
    {
        CreatePasswordHash(Customer.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //Customer.Password = System.Text.Encoding.UTF8.GetString(passwordHash);
        //Customer.PasswordSalt = System.Text.Encoding.UTF8.GetString(passwordSalt);
        Customer.Password = Convert.ToBase64String(passwordHash);
        Customer.PasswordSalt = Convert.ToBase64String(passwordSalt);
        
        await _customersRepository.RegisterCustomer(Customer);
    }
    
    public async Task<LoginCustomerResponse> LoginCustomer(UserDto user)
    {
        var CustomerInfo = await _customersRepository.GetCustomerInfoByUsername(user.Username);

        if (CustomerInfo == null)
            throw new Exception("User was not Found");

        var encodedPasswordHash = Convert.FromBase64String(CustomerInfo.Password);
        var encodedPasswordSalt = Convert.FromBase64String(CustomerInfo.PasswordSalt);

        if (!VerifyPasswordHash(user.Password, encodedPasswordHash, encodedPasswordSalt))
            throw new Exception("Wrong Password");

        var userModel = new UserModel();
        userModel.Username = user.Username;
        userModel.PasswordHash = encodedPasswordHash;
        userModel.PasswordSalt = encodedPasswordSalt;
        
        var token = CreateToken(userModel, CustomerInfo);
        var refreshToken = GenerateRefreshToken();

        return new LoginCustomerResponse
        {
            Token = token.Result,
            RefreshTokenModel = refreshToken.Result,
            CustomerInfo = new GetCustomersResponse
            {
                CustomerId = CustomerInfo.CustomerId,
                Username = CustomerInfo.Username,
                FirstName = CustomerInfo.FirstName,
                LastName = CustomerInfo.LastName,
                CountryId = CustomerInfo.CountryId,
                Email = CustomerInfo.Email,
            }
        };
    }

    public async Task<LoginCustomerResponse> RefreshToken(UserModel user)
    {
        var CustomerInfo = await _customersRepository.GetCustomerInfoByUsername(user.Username);
        var token = CreateToken(user, CustomerInfo);
        var newRefreshToken = GenerateRefreshToken();
        return new LoginCustomerResponse
        {
            Token = token.Result,
            RefreshTokenModel = newRefreshToken.Result,
            CustomerInfo = new GetCustomersResponse
            {
                CustomerId = CustomerInfo.CustomerId,
                Username = CustomerInfo.Username,
                FirstName = CustomerInfo.FirstName,
                LastName = CustomerInfo.LastName,
                CountryId = CustomerInfo.CountryId,
                Email = CustomerInfo.Email,
            }
        };
    }    
    
    public async Task UpdateCustomer(CustomerModel Customer)
    {
        await _customersRepository.UpdateCustomer(Customer);
    }

    public async Task DeleteCustomer(int CustomerId)
    {
        await _customersRepository.DeleteCustomer(CustomerId);
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
    
    public async Task<string> CreateToken(UserModel user, CustomerModel? Customer)
    {
        var CustomerId = Customer?.CustomerId != null ? Customer.CustomerId.ToString() : "0";

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, CustomerId)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    public async Task<RefreshTokenModel> GenerateRefreshToken()
    {
        var refreshToken = new RefreshTokenModel
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(1),
            Created = DateTime.Now
        };
        return refreshToken;
    }
}