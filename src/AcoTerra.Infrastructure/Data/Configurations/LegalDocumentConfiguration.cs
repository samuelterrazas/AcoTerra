using AcoTerra.Core.Entities.LegalDocuments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

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