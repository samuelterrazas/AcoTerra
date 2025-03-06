using AcoTerra.Core.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class FinancialInformationConfiguration : IEntityTypeConfiguration<FinancialInformation>
{
    public void Configure(EntityTypeBuilder<FinancialInformation> builder)
    {
        builder.ToTable("financial_information");

        builder.HasKey(financialInfo => financialInfo.Id);
        
        builder.Property(financialInfo => financialInfo.Id)
            .ValueGeneratedOnAdd();
    }
}