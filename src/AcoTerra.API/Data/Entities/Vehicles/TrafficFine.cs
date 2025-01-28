using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class TrafficFine : AuditableEntity
{
    public required Guid Id { get; set; }
    public required TrafficViolation Violation { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime DateIssued { get; set; }
    public DateOnly? PaidAt { get; set; }
    public string? Document { get; set; }
    
    public required Guid VehicleId { get; set; }
}

internal sealed class TrafficFineConfiguration : IEntityTypeConfiguration<TrafficFine>
{
    public void Configure(EntityTypeBuilder<TrafficFine> builder)
    {
        builder.ToTable("traffic_fines");

        builder.HasKey(fine => fine.Id);
        
        builder.Property(fine => fine.Id)
            .ValueGeneratedNever();

        builder.Property(fine => fine.Violation)
            .HasConversion(new EnumToStringConverter<TrafficViolation>());
    }
}