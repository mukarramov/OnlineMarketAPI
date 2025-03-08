using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface ICategoryRepository
{
    Task<Category?> GetByAsync(string categoryId);
    Task<IEnumerable<Category>> GetAllsAsync();
    Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentId);
    Task<Category?> GetCategoryWithSubCategoriesAsync(int id);
    Task AddAsync(Category category);
    void UpdateAsync(Category category);
    void DeleteAsync(int category);
    Task<Category?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
}