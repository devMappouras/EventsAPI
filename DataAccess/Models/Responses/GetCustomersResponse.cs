namespace DataAccess.Models.Responses;

public class GetCustomersResponse
{
    public int CustomerId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public bool RoleId { get; set; }
}
