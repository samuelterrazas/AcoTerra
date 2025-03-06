using AcoTerra.Core.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class AdditionalEquipmentConfiguration : IEntityTypeConfiguration<AdditionalEquipment>
{
    public void Configure(EntityTypeBuilder<AdditionalEquipment> builder)
    {
        builder.ToTable("additional_equipment");

        builder.HasKey(equipment => equipment.Id);
        
        builder.Property(equipment => equipment.Id)
            .ValueGeneratedOnAdd();
    }
}