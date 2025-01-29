using AcoTerra.API.Data.Entities.Customers;
using AcoTerra.API.Data.Entities.Freights.ValueObjects;
using AcoTerra.API.Data.Entities.Producers;
using AcoTerra.API.Data.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class Shipment : AuditableEntity
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public required Location Origin { get; set; } 
    public required Location Destination { get; set; }
    public required double Quantity { get; set; }
    public required decimal Price { get; set; }
    
    public int FreightId { get; set; }
    public Freight Freight { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int ProducerId { get; set; }
    public Producer Producer { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}

internal sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("shipments");
        
        builder.HasKey(shipment => shipment.Id);
        
        builder.Property(shipment => shipment.Id)
            .ValueGeneratedOnAdd();

        builder.OwnsOne(shipment => shipment.Origin);
        
        builder.OwnsOne(shipment => shipment.Destination);

        builder.HasOne(shipment => shipment.Customer)
            .WithMany()
            .HasForeignKey(shipment => shipment.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(shipment => shipment.Producer)
            .WithMany()
            .HasForeignKey(shipment => shipment.ProducerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(shipment => shipment.Product)
            .WithMany()
            .HasForeignKey(shipment => shipment.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}