using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(o => o.Id)
            .HasColumnName("id");


        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(150)")
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}
