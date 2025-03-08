using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Users> Users { get; set; }
}