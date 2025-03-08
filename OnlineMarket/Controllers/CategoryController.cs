using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Interface;
using OnlineMarket.Models;

namespace OnlineMarket.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<Category?> Create(string name, int? pId)
    {
        var category = await _categoryService.Create(new Category { Name = name, ParentCategoryId = pId });
        return category;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> Get()
    {
        return await _categoryService.GetAll();
    }

    [HttpGet]
    public async Task<Category?> GetById(string productId)
    {
        return await _categoryService.GetChild(productId);
    }

    [HttpDelete]
    public async Task<bool> DeleteProduct(int id)
    {
        return await _categoryService.Delete(id);
    }

    [HttpPut]
    public async Task<bool> UpdateProduct(int id, string name, int pid)
    {
        return await _categoryService.Update(id, name, pid);
    }
}