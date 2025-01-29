using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class FinancialInformation : AuditableEntity
{
    public int Id { get; set; }
    public decimal PurchasePrice { get; set; }
    public bool Financed { get; set; }
    public int Installments { get; set; }
    public decimal OutstandingBalance { get; set; }
}

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