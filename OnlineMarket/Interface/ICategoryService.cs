using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface ICategoryService
{
    Task<Category?> Create(Category categories);
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> GetChild(string productId);
    Task<bool> Delete(int id);
    Task<bool> Update(int id, string newName, int? pId);

}