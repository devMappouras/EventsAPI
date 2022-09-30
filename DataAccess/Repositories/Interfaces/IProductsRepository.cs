using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface IProductsRepository
{
    Task DeleteProduct(int ProductId);
    Task<ProductModel?> GetProductById(int id);
    Task<IEnumerable<GetProductsResponse>> GetProducts(int OrganiserId);
    Task InsertProduct(ProductModel Product);
    Task UpdateProduct(ProductModel Product);
}