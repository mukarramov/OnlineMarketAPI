using System.Data;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Context;
using OnlineMarket.Interface;
using OnlineMarket.Models;

namespace OnlineMarket.Repositoryes;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }

    public async Task<IEnumerable<Product?>> GetAllsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(string name, string description, double price, int categoryId, Category category)
    {
        var newProduct = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            CategoryId = categoryId,
            Category = category
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }

    public void DeleteAsync(int productId)
    {
        var findById = _context.Products.FirstOrDefault(x => x.Id == productId);
        if (findById == null)
        {
            throw new Exception("product not found!");
        }

        _context.Products.Remove(findById);
        _context.SaveChanges();
    }

    public async Task<Product?> GetByIdAsync(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
    }
}