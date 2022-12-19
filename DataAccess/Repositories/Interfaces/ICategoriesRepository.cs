using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ICategoriesRepository
{
    Task<IEnumerable<GetCategoriesResponse>> GetCategories();
    Task<CategoryModel> GetCategoryById(int collectionId);
    Task InsertCategory(CategoryModel collection);
    Task UpdateCategory(CategoryModel collection);
    Task DeleteCategory(int collectionId);
}