using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.ToTable("agents")
            .UseTphMappingStrategy()
            .HasDiscriminator(agent => agent.Type)
            .HasValue<Driver>(AgentType.Driver)
            .HasValue<Producer>(AgentType.Producer)
            .HasValue<Customer>(AgentType.Customer);
        
        builder.HasKey(agent => agent.Id);

        builder.HasMany(agent => agent.LegalDocuments)
            .WithOne()
            .HasForeignKey(document => document.AgentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}