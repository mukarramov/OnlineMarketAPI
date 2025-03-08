using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Configuration;

public class OrderConfiguration:IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasKey(x => x.Id);
    }
}