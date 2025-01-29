using AcoTerra.API.Data.Entities.Employees;
using AcoTerra.API.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Freights;

internal sealed class Freight : AuditableEntity
{
    public int Id { get; set; }
    public required string Number { get; set; } 
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public double TotalQuantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Remarks { get; set; }
    
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public int EmployeeId { get; set; }
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
            .ValueGeneratedOnAdd();

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