using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Models;

namespace OnlineMarket.Configuration;

public class ReviewConfiguration:IEntityTypeConfiguration<Reviews>
{
    public void Configure(EntityTypeBuilder<Reviews> builder)
    {
        builder.HasKey(x => x.Id);
    }
}