using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface IProductRepository
{
    Task<Product?> GetByAsync(int productId);
    Task<IEnumerable<Product?>> GetAllsAsync();
    Task AddAsync(string name, string description, double price, int categoryId, Category category);
    void UpdateAsync(Product product);
    void DeleteAsync(int product);
    Task<Product?> GetByIdAsync(int productId);
}