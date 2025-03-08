using OnlineMarket.Interface;
using OnlineMarket.Models;

namespace OnlineMarket.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product?> Create(string name, string description, double price, int categoryId, Category category)
    {
        var newProduct = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            CategoryId = categoryId,
            Category = category
        };

        await _repository.AddAsync(name, description, price, categoryId, category);
        return newProduct;
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await _repository.GetAllsAsync();
    }

    public async Task<Product?> GetChild(int productId)
    {
        return await _repository.GetByAsync(productId);
    }

    public Task<bool> Delete(int productId)
    {
        bool checkForDelete;

        _repository.DeleteAsync(productId);

        checkForDelete = true;

        return Task.FromResult(checkForDelete);
    }

    public async Task<bool> Update(int id, string name, string description, double price)
    {
        var updateProduct = await _repository.GetByIdAsync(id);

        if (updateProduct == null)
        {
            throw new Exception("should be not null!");
        }

        updateProduct.Name = name;
        updateProduct.Description = description;
        updateProduct.Price = price;

        return true;
    }
}