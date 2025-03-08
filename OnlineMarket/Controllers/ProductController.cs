using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Interface;
using OnlineMarket.Models;

namespace OnlineMarket.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public Task<Product> Create(string name, string description, double price, int categoryId, Category category)
    {
        _productService.Create(name, description, price, categoryId, category);
        var newProduct = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            CategoryId = categoryId,
            Category = category
        };
        return Task.FromResult(newProduct);
    }

    [HttpGet]
    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await _productService.GetAll();
    }

    [HttpGet]
    public async Task<Product?> GetByIdAsync(int productId)
    {
        return await _productService.GetChild(productId);
    }

    [HttpDelete]
    public async Task<bool> Delete(int productId)
    {
        return await _productService.Delete(productId);
    }

    [HttpPut]
    public async Task<bool> Update(int id, string name, string description, double price)
    {
        return await _productService.Update(id, name, description, price);
    }
}