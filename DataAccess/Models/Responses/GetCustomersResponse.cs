namespace DataAccess.Models.Responses;

public class GetCustomersResponse
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CountryId { get; set; }

    public string Username { get; set; } = string.Empty;
}
