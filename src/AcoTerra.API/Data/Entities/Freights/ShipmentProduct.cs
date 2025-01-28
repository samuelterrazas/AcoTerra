using AcoTerra.API.Data.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class ShipmentProduct
{
    public Guid ShipmentId { get; init; }
    public Guid ProductId { get; init; }
}

internal sealed class ShipmentProductConfiguration : IEntityTypeConfiguration<ShipmentProduct>
{
    public void Configure(EntityTypeBuilder<ShipmentProduct> builder)
    {
        builder.ToTable("shipments_products");

        builder.HasKey(shipmentProducer => new { shipmentProducer.ShipmentId, shipmentProducer.ProductId });

        builder.HasOne<Shipment>()
            .WithMany()
            .HasForeignKey(shipmentProducer => shipmentProducer.ShipmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(shipmentProducer => shipmentProducer.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}