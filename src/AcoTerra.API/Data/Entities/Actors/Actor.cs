using AcoTerra.API.Data.Entities.Actors.Enums;
using AcoTerra.API.Data.Entities.LegalDocuments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Actors;

internal abstract class Actor : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required IdentificationType IdentificationType { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }

    public ICollection<LegalDocument> LegalDocuments { get; set; } = [];
}

internal sealed class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.UseTpcMappingStrategy();
        
        builder.HasKey(actor => actor.Id);

        builder.HasMany(actor => actor.LegalDocuments)
            .WithOne()
            .HasForeignKey(document => document.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}