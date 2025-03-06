using AcoTerra.Core.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(vehicle => vehicle.Id);

        builder.HasOne(vehicle => vehicle.TechnicalInformation)
            .WithOne()
            .HasForeignKey<TechnicalInformation>(information => information.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(vehicle => vehicle.FinancialInformation)
            .WithOne()
            .HasForeignKey<FinancialInformation>(information => information.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(vehicle => vehicle.LegalDocuments)
            .WithOne()
            .HasForeignKey(document => document.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(vehicle => vehicle.MaintenanceHistory)
            .WithOne()
            .HasForeignKey(history => history.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(vehicle => vehicle.TrafficFines)
            .WithOne()
            .HasForeignKey(fine => fine.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(vehicle => vehicle.AdditionalEquipment)
            .WithOne()
            .HasForeignKey(equipment => equipment.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(vehicle => vehicle.Driver)
            .WithMany()
            .HasForeignKey(vehicle => vehicle.DriverId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}