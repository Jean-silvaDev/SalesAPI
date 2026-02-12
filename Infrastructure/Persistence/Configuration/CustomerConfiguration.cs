using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("name")
               .HasColumnType("nvarchar(200)");

        builder.Property(x => x.Email)
               .IsRequired(false)
               .HasColumnName("email")
               .HasColumnType("nvarchar(100)");

        builder.HasIndex(x => x.Email)
               .IsUnique();

        builder.Property(x => x.CPF)
               .IsRequired(false)
               .HasColumnName("cpf")
               .HasColumnType("nvarchar(20)");

        builder.Property(x => x.PhoneNumber)
            .IsRequired(false)
            .HasColumnName("phone_number")
            .HasColumnType("nvarchar(30)");

        builder.HasMany(x => x.Orders)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
