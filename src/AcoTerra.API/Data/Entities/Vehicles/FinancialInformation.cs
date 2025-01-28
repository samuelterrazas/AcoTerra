using AcoTerra.API.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Vehicles;

internal sealed class FinancialInformation : AuditableEntity
{
    public Guid Id { get; set; }
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

        builder.HasKey(information => information.Id);
        
        builder.Property(information => information.Id)
            .ValueGeneratedNever();
    }
}