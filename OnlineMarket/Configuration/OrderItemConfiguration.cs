using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Models;

namespace OnlineMarket.Configuration;

public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItems>
{
    public void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        builder.HasKey(x => x.Id);
    }
}