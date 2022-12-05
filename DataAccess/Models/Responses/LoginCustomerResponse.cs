using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class LoginCustomerResponse
{
    public string Token { get; set; } = string.Empty;
    public RefreshTokenModel RefreshTokenModel { get; set; } = new RefreshTokenModel();
    
    public GetCustomersResponse? CustomerInfo { get; set; }
}