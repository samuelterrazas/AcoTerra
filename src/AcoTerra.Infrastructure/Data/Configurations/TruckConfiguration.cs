using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class TruckConfiguration : IEntityTypeConfiguration<Truck>
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.HasOne(truck => truck.Trailer)
            .WithOne()
            .HasForeignKey<Trailer>(trailer => trailer.TruckId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}