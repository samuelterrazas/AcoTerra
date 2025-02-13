using AcoTerra.API.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Trucks;

internal sealed class Truck : Vehicle
{
    public int TrailerId { get; set; }
    
    public Trailer? Trailer { get; set; }
}

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