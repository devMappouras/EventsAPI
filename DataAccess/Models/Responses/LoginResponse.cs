namespace DataAccess.Models.Responses;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    
    public GetOrganisersResponse? OrganiserInfo { get; set; }
}
