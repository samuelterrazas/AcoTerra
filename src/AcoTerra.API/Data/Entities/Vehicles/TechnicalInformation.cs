using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class TechnicalInformation : AuditableEntity
{
    public int Id { get; set; }
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

        builder.HasKey(technicalInfo => technicalInfo.Id);
        
        builder.Property(technicalInfo => technicalInfo.Id)
            .ValueGeneratedOnAdd();
    }
}