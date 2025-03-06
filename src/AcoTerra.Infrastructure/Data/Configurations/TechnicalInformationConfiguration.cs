using AcoTerra.Core.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

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