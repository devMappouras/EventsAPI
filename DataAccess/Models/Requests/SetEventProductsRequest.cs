namespace DataAccess.Models.Requests;

public class SetEventProductsRequest
{
    public SetEventProductsRequest(int eventId, string productsIds)
    {
        EventId = eventId;
        ProductsIds = productsIds;
    }

    public int EventId { get; }
    public string ProductsIds { get; }
}