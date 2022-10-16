namespace DataAccess.Models.Requests;

public class SetEventProductsRequest
{
    public int EventId { get; set; }
    public string ProductIds { get; set; } = String.Empty;
}