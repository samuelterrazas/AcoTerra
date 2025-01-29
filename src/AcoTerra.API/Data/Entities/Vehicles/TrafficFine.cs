using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class TrafficFine : AuditableEntity
{
    public int Id { get; set; }
    public required TrafficViolation Violation { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime DateIssued { get; set; }
    public DateOnly? PaidAt { get; set; }
    public string? Document { get; set; }
    
    public int VehicleId { get; set; }
}

internal sealed class TrafficFineConfiguration : IEntityTypeConfiguration<TrafficFine>
{
    public void Configure(EntityTypeBuilder<TrafficFine> builder)
    {
        builder.ToTable("traffic_fines");

        builder.HasKey(trafficFine => trafficFine.Id);
        
        builder.Property(trafficFine => trafficFine.Id)
            .ValueGeneratedOnAdd();
    }
}