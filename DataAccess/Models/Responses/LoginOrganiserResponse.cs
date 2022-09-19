using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class LoginOrganiserResponse
{
    public string Token { get; set; } = string.Empty;
    public RefreshTokenModel RefreshTokenModel { get; set; } = new RefreshTokenModel();
    
    public GetOrganisersResponse? OrganiserInfo { get; set; }
}