using Microsoft.EntityFrameworkCore;
using OA.Core.Domain;
using OA.Data;

namespace OA.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public virtual async Task InsertCategoryAsync(Category category)
    {
        await _categoryRepository.InsertAsync(category);
    }

    public virtual async Task UpdateCategoryAsync(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
    }

    public virtual async Task DeleteCategoryAsync(Category category)
    {
        await _categoryRepository.DeleteAsync(category);
    }

    public virtual async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        return await _categoryRepository.GetByIdAsync(categoryId);
    }

    public virtual async Task<IEnumerable<Category>> GetAllCategory()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public virtual async Task<int> GetTotalCategoriesAsync()
    {
        return await _categoryRepository.Table.CountAsync();
    }
}
