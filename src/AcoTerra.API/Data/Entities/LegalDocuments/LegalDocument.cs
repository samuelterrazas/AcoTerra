using AcoTerra.API.Data.Entities.Common;
using AcoTerra.API.Data.Entities.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcoTerra.API.Data.Entities.LegalDocuments;

public sealed class LegalDocument : AuditableEntity
{
    public required Guid Id { get; set; }
    public required LegalDocumentType Type { get; set; }
    public required string Document { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    
    public Guid? VehicleId { get; set; }
    public Guid? ActorId { get; set; }
}

internal sealed class LegalDocumentConfiguration : IEntityTypeConfiguration<LegalDocument>
{
    public void Configure(EntityTypeBuilder<LegalDocument> builder)
    {
        builder.ToTable("legal_documents");
        
        builder.HasKey(document => document.Id);
        
        builder.Property(document => document.Id)
            .ValueGeneratedNever();

        builder.Property(document => document.Type)
            .HasConversion(new EnumToStringConverter<LegalDocumentType>());
    }
}