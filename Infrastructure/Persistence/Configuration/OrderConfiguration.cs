using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("id");

        builder.Property(o => o.CreatedDate)
            .HasColumnType("datetime2")
            .HasColumnName("created_date");

        builder.Property(o => o.UpdatedDate)
            .HasColumnType("datetime2")
            .HasColumnName("updated_date");

        builder.Property(o => o.InsertedDate)
            .HasColumnType("datetime2")
            .HasColumnName("inserted_date");

        builder.Property(o => o.Description)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("description");

        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.Products)
            .WithMany()
            .UsingEntity(j => j.ToTable("order_products"));
    }
}
