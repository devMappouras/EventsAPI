namespace DataAccess.Models.Responses;

public class GetEventProductsForCustomerResponse
{
    public int EventProductId { get; set; }
    public int ProductId { get; set; }
    public int HierarchyId { get; set; }
    public string HierarchyName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int SectionId { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public int Capacity { get; set; }
}