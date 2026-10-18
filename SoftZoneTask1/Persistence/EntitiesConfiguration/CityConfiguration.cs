using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftZoneTask1.Domain.Entities;

namespace SoftZoneTask1.Persistence.EntitiesConfiguration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasMany(c => c.Restaurants)
            .WithOne(r => r.City)
            .HasForeignKey(r => r.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}