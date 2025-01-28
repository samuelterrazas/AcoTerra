using AcoTerra.API.Data.Entities.Producers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class ShipmentProducer
{
    public Guid ShipmentId { get; init; }
    public Guid ProducerId { get; init; }
}

internal sealed class ShipmentProducerConfiguration : IEntityTypeConfiguration<ShipmentProducer>
{
    public void Configure(EntityTypeBuilder<ShipmentProducer> builder)
    {
        builder.ToTable("shipments_producers");

        builder.HasKey(shipmentProducer => new { shipmentProducer.ShipmentId, shipmentProducer.ProducerId });

        builder.HasOne<Shipment>()
            .WithMany()
            .HasForeignKey(shipmentProducer => shipmentProducer.ShipmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Producer>()
            .WithMany()
            .HasForeignKey(shipmentProducer => shipmentProducer.ProducerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}