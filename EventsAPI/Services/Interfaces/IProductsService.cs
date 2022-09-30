using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces
{
    public interface IProductsService
    {
        Task InsertProduct(ProductModel Product);

        Task UpdateProduct(ProductModel Product);

        Task DeleteProduct(int ProductId);

        Task<ProductModel> GetProductById(int id);

        Task<IEnumerable<GetProductsResponse>> GetProducts();
    }
}
