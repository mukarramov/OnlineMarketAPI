using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface IOrderRepository
{
    Task<OrderItems?> GetByAsync(string categoryId);
    Task<IEnumerable<OrderItems>> GetAllsAsync();
    Task<IEnumerable<OrderItems>> GetSubCategoriesAsync(int parentId);
    Task<OrderItems?> GetCategoryWithSubCategoriesAsync(int id);
    Task AddAsync(OrderItems category);
    void UpdateAsync(OrderItems category);
    void DeleteAsync(OrderItems category);
    Task<bool> ExistsAsync(int id);
}