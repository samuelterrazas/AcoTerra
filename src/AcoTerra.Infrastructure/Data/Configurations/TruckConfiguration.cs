using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class TruckConfiguration : IEntityTypeConfiguration<Truck>
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.ToTable("trucks");
        
        builder.Property(truck => truck.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(truck => truck.Trailer)
            .WithOne()
            .HasForeignKey<Truck>(truck => truck.TrailerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}