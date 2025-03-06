using AcoTerra.Core.Entities.Freights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class FreightConfiguration : IEntityTypeConfiguration<Freight>
{
    public void Configure(EntityTypeBuilder<Freight> builder)
    {
        builder.ToTable("freight");

        builder.HasKey(freight => freight.Id);
        
        builder.Property(freight => freight.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(freight => freight.Truck)
            .WithMany()
            .HasForeignKey(freight => freight.TruckId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(freight => freight.Shipments)
            .WithOne(shipment => shipment.Freight)
            .HasForeignKey(shipment => shipment.FreightId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}