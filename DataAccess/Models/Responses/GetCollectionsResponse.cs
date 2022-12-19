namespace DataAccess.Models.Responses;

public class GetCollectionsResponse
{
    public int CollectionId { get; set; }
    public string? CollectionName { get; set; } = string.Empty;
}
