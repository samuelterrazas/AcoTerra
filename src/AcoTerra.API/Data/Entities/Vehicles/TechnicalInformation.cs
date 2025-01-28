using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcoTerra.API.Data.Entities.Vehicles;

public sealed class TechnicalInformation : AuditableEntity
{
    public Guid Id { get; set; }
    public double CurrentMileage { get; set; }
    public FuelType FuelType { get; set; }
    public double AverageConsumption { get; set; }
    public double TankSize { get; set; }
}

internal sealed class TechnicalInformationConfiguration : IEntityTypeConfiguration<TechnicalInformation>
{
    public void Configure(EntityTypeBuilder<TechnicalInformation> builder)
    {
        builder.ToTable("technical_information");

        builder.HasKey(information => information.Id);
        
        builder.Property(information => information.Id)
            .ValueGeneratedNever();

        builder.Property(information => information.FuelType)
            .HasConversion(new EnumToStringConverter<FuelType>());
    }
}