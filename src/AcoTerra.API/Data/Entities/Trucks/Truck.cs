using AcoTerra.API.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Trucks;

internal sealed class Truck : Vehicle
{
    public Trailer? Trailer { get; set; }
}

internal sealed class TruckConfiguration : IEntityTypeConfiguration<Truck>
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.ToTable("trucks");

        builder.HasOne(truck => truck.Trailer)
            .WithOne()
            .HasForeignKey<Trailer>(trailer => trailer.TruckId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}