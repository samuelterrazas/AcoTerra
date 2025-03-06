using AcoTerra.Core.Entities.Freights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("shipments");
        
        builder.HasKey(shipment => shipment.Id);
        
        builder.Property(shipment => shipment.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(shipment => shipment.Producer)
            .WithMany()
            .HasForeignKey(shipment => shipment.ProducerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(shipment => shipment.Product)
            .WithMany()
            .HasForeignKey(shipment => shipment.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(shipment => shipment.Customer)
            .WithMany()
            .HasForeignKey(shipment => shipment.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}