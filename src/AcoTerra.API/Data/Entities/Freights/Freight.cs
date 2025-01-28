using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Employees;
using AcoTerra.API.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class Freight : AuditableEntity
{
    public required Guid Id { get; set; }
    public required string Number { get; set; }
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public double TotalQuantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Remarks { get; set; }
    
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public ICollection<Shipment> Shipments { get; set; } = [];
}

internal sealed class FreightConfiguration : IEntityTypeConfiguration<Freight>
{
    public void Configure(EntityTypeBuilder<Freight> builder)
    {
        builder.ToTable("freight");

        builder.HasKey(freight => freight.Id);
        
        builder.Property(freight => freight.Id)
            .ValueGeneratedNever();

        builder.HasOne(freight => freight.Vehicle)
            .WithMany()
            .HasForeignKey(freight => freight.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(freight => freight.Employee)
            .WithMany()
            .HasForeignKey(freight => freight.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(freight => freight.Shipments)
            .WithOne(shipment => shipment.Freight)
            .HasForeignKey(shipment => shipment.FreightId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}