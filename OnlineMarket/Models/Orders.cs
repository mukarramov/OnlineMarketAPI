using OnlineMarket.Models.Enums;

namespace OnlineMarket.Models;
public class Orders
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreateAt { get; set; }
    public Status Status { get; set; }
}