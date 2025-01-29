using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.LegalDocuments;

internal sealed class LegalDocument : AuditableEntity
{
    public int Id { get; set; }
    public required LegalDocumentType Type { get; set; }
    public required string Document { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    
    public int? VehicleId { get; set; }
    public int? ActorId { get; set; }
}

internal sealed class LegalDocumentConfiguration : IEntityTypeConfiguration<LegalDocument>
{
    public void Configure(EntityTypeBuilder<LegalDocument> builder)
    {
        builder.ToTable("legal_documents");
        
        builder.HasKey(legalDocument => legalDocument.Id);
        
        builder.Property(legalDocument => legalDocument.Id)
            .ValueGeneratedOnAdd();
    }
}