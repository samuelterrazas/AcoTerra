using AcoTerra.API.Data.Entities.Trucks;
using AcoTerra.API.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class Freight : AuditableEntity
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public required int TruckId { get; set; }
    public required DateOnly LoadingDate { get; set; }
    public required DateOnly UnloadingDate { get; set; }
    public decimal TotalShipmentQuantity { get; set; }
    public decimal TotalShipmentWeight { get; set; }
    public decimal TotalShipmentAmount { get; set; }
    public string? Remarks { get; set; }
    
    
    public Truck Truck { get; set; } = null!;
    public ICollection<Shipment> Shipments { get; set; } = [];
}

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