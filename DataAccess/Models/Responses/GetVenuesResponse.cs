namespace DataAccess.Models.Responses;

public class GetVenuesResponse
{
    public int? VenueId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? Town { get; set; } = string.Empty;
    public string? CountryId { get; set; }
    public string? CountryName { get; set; } = string.Empty;
}
