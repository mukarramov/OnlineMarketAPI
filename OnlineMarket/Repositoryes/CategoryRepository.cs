using Microsoft.EntityFrameworkCore;
using OnlineMarket.Context;
using OnlineMarket.Interface;
using OnlineMarket.Models;

namespace OnlineMarket.Repositoryes;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByAsync(string categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    public async Task<IEnumerable<Category>> GetAllsAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentId)
    {
        return await _context.Categories.Where(x => x.ParentCategoryId == parentId).ToListAsync();
    }

    public async Task<Category?> GetCategoryWithSubCategoriesAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public void UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void DeleteAsync(int categoryId)
    {
        var c = _context.Categories.FirstOrDefault(x => x.Id == categoryId);
        _context.Categories.Remove(c);
        _context.SaveChanges();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Categories.AnyAsync(x => x.Id == id);
    }
}