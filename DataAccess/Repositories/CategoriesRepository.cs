using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly ISqlDataAccess _db;

    public CategoriesRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetCategoriesResponse>> GetCategories() => await _db.LoadData<GetCategoriesResponse, dynamic>("Categories_GetAll", new {} );

    public async Task<CategoryModel> GetCategoryById(int categoryId)
    {
        var results = await _db.LoadData<CategoryModel, dynamic>("Categories_Get", new { CategoryId = categoryId });
        return results.FirstOrDefault();
    }

    public Task InsertCategory(CategoryModel category) => _db.SaveData("Categories_Insert", new { category.CategoryName });

    public Task UpdateCategory(CategoryModel category) => _db.SaveData("Categories_Update", category);

    public Task DeleteCategory(int categoryId) => _db.SaveData("Categories_Delete", new { CategoryId = categoryId });
}