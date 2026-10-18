using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftZoneTask1.Domain.Entities;

namespace SoftZoneTask1.Persistence.EntitiesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(250);

        builder
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
