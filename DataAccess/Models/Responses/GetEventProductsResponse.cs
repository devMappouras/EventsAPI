namespace DataAccess.Models.Responses;

public class GetEventProductsResponse
{
    public List<GetProductsResponse> AvailableProducts { get; set; }
    public List<GetProductsResponse> SelectedProducts { get; set; }
}
