using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ISqlDataAccess _db;

    public ProductsRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetProductsResponse>> GetProducts(int OrganiserId) => 
        await _db.LoadData<GetProductsResponse, dynamic>("Products_GetAll", new { OrganiserId });

    public async Task<ProductModel?> GetProductById(int ProductId)
    {
        var results = await _db.LoadData<ProductModel, dynamic>("Products_Get", new { ProductId });
        return results.FirstOrDefault();
    }

    public Task InsertProduct(ProductModel Product) => _db.SaveData("Products_Insert",
        new
        {
            Product.VenueId,
            Product.OrganiserId,
            Product.HierarchyId,
            Product.Price
        });

    public Task UpdateProduct(ProductModel Product) => _db.SaveData("Products_Update", Product);

    public Task DeleteProduct(int ProductId) => _db.SaveData("Products_Delete", new { ProductId });
    
    public async Task<GetEventProductsResponse> GetEventProducts(int EventId, int OrganiserId)     
    {
        var availableProducts = await _db.LoadData<GetProductsResponse, dynamic>("Products_GetAvailableProducts", new { EventId, OrganiserId });
        var selectedProducts = await _db.LoadData<GetProductsResponse, dynamic>("Products_GetSelectedProducts", new { EventId });
        
        return new GetEventProductsResponse
        {
            AvailableProducts = availableProducts.ToList(),
            SelectedProducts = selectedProducts.ToList()
        };
    }
}
