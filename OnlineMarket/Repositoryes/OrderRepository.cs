using Microsoft.EntityFrameworkCore;
using OnlineMarket.Context;
using OnlineMarket.Interface;
using OnlineMarket.Models;

namespace OnlineMarket.Repositoryes;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItems?> GetByAsync(string orderId)
    {
        return await _context.OrderItems.FindAsync(orderId);
    }

    public async Task<IEnumerable<OrderItems>> GetAllsAsync()
    {
        return await _context.OrderItems.ToListAsync();
    }

    public async Task<IEnumerable<OrderItems>> GetSubCategoriesAsync(int orderId)
    {
        return await _context.OrderItems.Where(x => x.OrderId == orderId).ToListAsync();
    }

    public async Task<OrderItems?> GetCategoryWithSubCategoriesAsync(int id)
    {
        return await _context.OrderItems.FindAsync(id);
    }

    public async Task AddAsync(OrderItems orderItems)
    {
        await _context.OrderItems.AddAsync(orderItems);
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(OrderItems orderItem)
    {
        _context.OrderItems.Update(orderItem);
    }

    public void DeleteAsync(OrderItems orderItem)
    {
        _context.OrderItems.Remove(orderItem);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.OrderItems.AnyAsync(x => x.Id == id);
    }
}