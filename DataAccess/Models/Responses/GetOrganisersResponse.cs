namespace DataAccess.Models.Responses;

public class GetOrganisersResponse
{
    public int OrganiserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public bool RoleId { get; set; }
}
