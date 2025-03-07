using AcoTerra.Core.Entities.Actors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

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