using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class AdditionalEquipment : AuditableEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Cost { get; set; }
    public required EquipmentCondition Condition { get; set; }
    
    public required Guid VehicleId { get; set; }
}

internal sealed class AdditionalEquipmentConfiguration : IEntityTypeConfiguration<AdditionalEquipment>
{
    public void Configure(EntityTypeBuilder<AdditionalEquipment> builder)
    {
        builder.ToTable("additional_equipment");

        builder.HasKey(equipment => equipment.Id);
        
        builder.Property(equipment => equipment.Id)
            .ValueGeneratedNever();
        
        builder.Property(equipment => equipment.Condition)
            .HasConversion(new EnumToStringConverter<EquipmentCondition>());
    }
}