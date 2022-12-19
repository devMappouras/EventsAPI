using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _CategoriesRepository;

    public CategoriesService(ICategoriesRepository CategoriesRepository)
    {
        _CategoriesRepository = CategoriesRepository;
    }
    
    public async Task InsertCategory(CategoryModel Category)
    {
        await _CategoriesRepository.InsertCategory(Category);
    }

    public async Task UpdateCategory(CategoryModel Category)
    {
        await _CategoriesRepository.UpdateCategory(Category);
    }

    public async Task DeleteCategory(int CategoryId)
    {
        await _CategoriesRepository.DeleteCategory(CategoryId);
    }

    public async Task<CategoryModel> GetCategoryById(int CategoryId)
    {
       return await _CategoriesRepository.GetCategoryById(CategoryId);
    }

    public async Task<IEnumerable<GetCategoriesResponse>> GetCategories()
    {
        return await _CategoriesRepository.GetCategories();
    }
}