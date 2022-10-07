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
            Product.Capacity,
            Product.OrganiserId,
            Product.HierarchyId,
            Product.Price
        });

    public Task UpdateProduct(ProductModel Product) => 
        _db.SaveData("Products_Update", Product);

    public Task DeleteProduct(int ProductId) => 
        _db.SaveData("Products_Delete", new { ProductId });
}
