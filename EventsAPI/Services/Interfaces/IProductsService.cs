using DataAccess.Models.Responses;
using DataAccess.Models;
using DataAccess.Models.Requests;

namespace EventsAPI.Services.Interfaces
{
    public interface IProductsService
    {
        Task InsertProduct(ProductModel Product);

        Task UpdateProduct(ProductModel Product);

        Task DeleteProduct(int ProductId);

        Task<ProductModel> GetProductById(int id);

        Task<IEnumerable<GetProductsResponse>> GetProducts();
        
        Task<GetEventProductsResponse> GetEventProducts(int EventId);
        Task SetEventProducts(SetEventProductsRequest request);
    }
}
