using AcoTerra.API.Data.Entities.Customers;
using AcoTerra.API.Data.Entities.Freights.Enums;
using AcoTerra.API.Data.Entities.Producers;
using AcoTerra.API.Data.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class Shipment : AuditableEntity
{
    public int Id { get; set; }
    public required int FreightId { get; set; }
    public required string Number { get; set; }
    public required int ProducerId { get; set; }
    public required int ProductId { get; set; }
    public required decimal TotalProductQuantity { get; set; }
    public required decimal TotalProductWeight { get; set; }
    public required decimal TotalProductAmount { get; set; }
    public required int CustomerId { get; set; }
    public required string Location { get; set; }
    public required ShipmentStatus Status { get; set; }
    
    public Freight Freight { get; set; } = null!;
    public Producer Producer { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}

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