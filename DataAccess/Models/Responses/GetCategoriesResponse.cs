namespace DataAccess.Models.Responses;

public class GetCategoriesResponse
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; } = string.Empty;
}
