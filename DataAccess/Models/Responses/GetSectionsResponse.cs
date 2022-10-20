namespace DataAccess.Models.Responses;

public class GetSectionsResponse
{
    public int SectionId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public int HierarchyId { get; set; }
    public string? HierarchyName { get; set; } = string.Empty;
}
