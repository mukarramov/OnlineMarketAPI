using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface IOrderService
{
    Task<OrderItems> Create(OrderItems orderItems);
    List<OrderItems> GetAll();
    Task<OrderItems> GetChild(int orderId);
    Task<bool> Delete(int productId);
    Task<bool> Update(int id, int orderId, int productId, int quantity);
}