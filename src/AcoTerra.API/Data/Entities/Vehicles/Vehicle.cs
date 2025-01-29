using AcoTerra.API.Data.Entities.LegalDocuments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal abstract class Vehicle : AuditableEntity
{
    public int Id { get; set; }
    public required string LicensePlate { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required int ManufacturingYear { get; set; }
    public required string ChassisNumber { get; set; }
    public required string EngineNumber { get; set; }

    public TechnicalInformation TechnicalInformation { get; set; } = null!;
    public FinancialInformation FinancialInformation { get; set; } = null!;
    public ICollection<LegalDocument> LegalDocuments { get; set; } = [];
    public ICollection<MaintenanceHistory> MaintenanceHistory { get; set; } = [];
    public ICollection<TrafficFine> TrafficFines { get; set; } = [];
    public ICollection<AdditionalEquipment> AdditionalEquipment { get; set; } = [];
}

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
    }
}