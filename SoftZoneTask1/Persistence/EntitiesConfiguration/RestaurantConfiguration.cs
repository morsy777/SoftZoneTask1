using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftZoneTask1.Domain.Entities;

namespace SoftZoneTask1.Persistence.EntitiesConfiguration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .Property(r => r.Address)
            .HasMaxLength(250);

        builder
            .HasOne(r => r.City)
            .WithMany(c => c.Restaurants)
            .HasForeignKey(r => r.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(r => r.MenuItems)
            .WithOne(m => m.Restaurant)
            .HasForeignKey(m => m.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(r => r.Orders)
            .WithOne(o => o.Restaurant)
            .HasForeignKey(o => o.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}