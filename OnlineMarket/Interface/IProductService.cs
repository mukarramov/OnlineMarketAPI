using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface IProductService
{
    Task<Product?> Create(string name, string description, double price, int categoryId, Category category);
    Task<IEnumerable<Product?>> GetAll();
    Task<Product?> GetChild(int productId);
    Task<bool> Delete(int productId);
    Task<bool> Update(int id, string name, string description, double price);
}