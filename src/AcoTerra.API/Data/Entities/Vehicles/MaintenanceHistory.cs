using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class MaintenanceHistory : AuditableEntity
{
    public int Id { get; set; }
    public required int VehicleId { get; set; }
    public required DateOnly Date { get; set; }
    public required string Type { get; set; }
    public required decimal Cost { get; set; }
    public string? Document { get; set; }
}

internal sealed class MaintenanceHistoryConfiguration : IEntityTypeConfiguration<MaintenanceHistory>
{
    public void Configure(EntityTypeBuilder<MaintenanceHistory> builder)
    {
        builder.ToTable("maintenance_history");

        builder.HasKey(maintenanceHistory => maintenanceHistory.Id);
        
        builder.Property(maintenanceHistory => maintenanceHistory.Id)
            .ValueGeneratedOnAdd();
    }
}