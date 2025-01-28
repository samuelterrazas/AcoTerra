using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Customers;
using AcoTerra.API.Data.Entities.Freights.ValueObjects;
using AcoTerra.API.Data.Entities.Producers;
using AcoTerra.API.Data.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

public sealed class Shipment : AuditableEntity
{
    public required Guid Id { get; set; }
    public required string Number { get; set; }
    public required Location Origin { get; set; }
    public required Location Destination { get; set; }
    public required double Quantity { get; set; }
    public required decimal Price { get; set; }
    
    public Guid FreightId { get; set; }
    public Freight Freight { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public ICollection<Producer> Producers { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}

internal sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("shipments");
        
        builder.HasKey(shipment => shipment.Id);
        
        builder.Property(shipment => shipment.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(shipment => shipment.Origin);
        
        builder.OwnsOne(shipment => shipment.Destination);

        builder.HasOne(shipment => shipment.Customer)
            .WithMany()
            .HasForeignKey(shipment => shipment.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(shipment => shipment.Producers)
            .WithMany()
            .UsingEntity<ShipmentProducer>();

        builder.HasMany(shipment => shipment.Products)
            .WithMany()
            .UsingEntity<ShipmentProduct>();
    }
}