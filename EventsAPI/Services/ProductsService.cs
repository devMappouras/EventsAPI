using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _ProductsRepository;
        private readonly IUserService _userService;

        public ProductsService(IProductsRepository ProductsRepository, IUserService userService)
        {
            _ProductsRepository = ProductsRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<GetProductsResponse>> GetProducts()
        {
            return await _ProductsRepository.GetProducts(_userService.GetLoggedInOrganiserId());
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _ProductsRepository.GetProductById(id);
        }

        public async Task InsertProduct(ProductModel Product)
        {
            Product.OrganiserId = _userService.GetLoggedInOrganiserId();
            await _ProductsRepository.InsertProduct(Product);
        }

        public async Task UpdateProduct(ProductModel Product)
        {
            Product.OrganiserId = _userService.GetLoggedInOrganiserId();
            await _ProductsRepository.UpdateProduct(Product);
        }

        public async Task DeleteProduct(int ProductId)
        {
            await _ProductsRepository.DeleteProduct(ProductId);
        }

        public async Task<GetEventProductsResponse> GetEventProducts(int EventId)
        {
            var OrganiserId = _userService.GetLoggedInOrganiserId();
            return await _ProductsRepository.GetEventProducts(EventId, OrganiserId);
        }
    }
}