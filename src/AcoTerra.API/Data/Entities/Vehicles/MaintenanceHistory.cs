using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class MaintenanceHistory : AuditableEntity
{
    public required Guid Id { get; set; }
    public required DateOnly Date { get; set; }
    public required MaintenanceType Type { get; set; }
    public required decimal Cost { get; set; }
    public string? Tires { get; set; }
    public string? Document { get; set; }
    
    public required Guid VehicleId { get; set; }
}

internal sealed class MaintenanceHistoryConfiguration : IEntityTypeConfiguration<MaintenanceHistory>
{
    public void Configure(EntityTypeBuilder<MaintenanceHistory> builder)
    {
        builder.ToTable("maintenance_history");

        builder.HasKey(history => history.Id);
        
        builder.Property(history => history.Id)
            .ValueGeneratedNever();

        builder.Property(history => history.Type)
            .HasConversion(new EnumToStringConverter<MaintenanceType>());
    }
}