using AcoTerra.Core.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

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