using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces;

public interface ICategoriesService
{
    Task InsertCategory(CategoryModel Category);

    Task UpdateCategory(CategoryModel Category);

    Task DeleteCategory(int id);

    Task<CategoryModel> GetCategoryById(int id);

    Task<IEnumerable<GetCategoriesResponse>> GetCategories();
}