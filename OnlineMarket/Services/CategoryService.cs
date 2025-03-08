using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Context;
using OnlineMarket.Interface;
using OnlineMarket.Models;
using OnlineMarket.Repositoryes;

namespace OnlineMarket.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<Category?> Create(Category categories)
    {
        var category = new Category
        {
            Name = categories.Name,
            ParentCategoryId = categories.ParentCategoryId
        };
        await _repository.AddAsync(category);
        return category;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _repository.GetAllsAsync();
    }

    public async Task<Category?> GetChild(string productId)
    {
        return await _repository.GetByAsync(productId);
    }

    public Task<bool> Delete(int id)
    {
        bool checkForDelete = false;

        _repository.DeleteAsync(id);

        checkForDelete = true;

        return Task.FromResult(checkForDelete);
    }

    public async Task<bool> Update(int id, string newName, int? pId)

    {
        var category = await _repository.GetByIdAsync(id);
        category.Name = newName;
        category.ParentCategoryId = pId ?? category.ParentCategoryId;
         _repository.UpdateAsync(category);
        return true;
    }
}