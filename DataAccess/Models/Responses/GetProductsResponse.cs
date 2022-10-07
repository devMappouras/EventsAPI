namespace DataAccess.Models.Responses;

public class GetProductsResponse
{
    public int ProductId { get; set; }
    public int VenueId { get; set; }
    public string? VenueName { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int OrganiserId { get; set; }
    public int HierarchyId { get; set; }
    public string? HierarchyName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
