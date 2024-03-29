﻿using DataAccess.Models;
using DataAccess.Models.Requests;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface IProductsRepository
{
    Task DeleteProduct(int ProductId);
    Task<ProductModel?> GetProductById(int id);
    Task<IEnumerable<GetProductsResponse>> GetProducts(int OrganiserId);
    Task InsertProduct(ProductModel Product);
    Task UpdateProduct(ProductModel Product);
    Task<GetEventProductsResponse> GetEventProducts(int EventId, int OrganiserId);
    Task SetEventProducts(SetEventProductsRequest request);
}