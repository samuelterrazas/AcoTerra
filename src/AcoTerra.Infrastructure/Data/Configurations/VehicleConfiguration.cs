using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Trucks;
using AcoTerra.Core.Entities.Vehicles;
using AcoTerra.Core.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles")
            .UseTphMappingStrategy()
            .HasDiscriminator(vehicle => vehicle.Type)
            .HasValue<Truck>(VehicleType.Truck);

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
            .WithOne()
            .HasForeignKey<Driver>(driver => driver.VehicleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}