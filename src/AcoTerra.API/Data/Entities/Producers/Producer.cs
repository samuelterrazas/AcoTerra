using AcoTerra.API.Data.Entities.Actors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Producers;

internal sealed class Producer : Actor
{
}

internal sealed class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.ToTable("producers");
        
        builder.Property(producer => producer.Id)
            .ValueGeneratedOnAdd();
    }
}