using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class TrailerConfiguration : IEntityTypeConfiguration<Trailer>
{
    public void Configure(EntityTypeBuilder<Trailer> builder)
    {
        builder.ToTable("trailers");

        builder.HasKey(trailer => trailer.Id);
        
        builder.Property(trailer => trailer.Id)
            .ValueGeneratedOnAdd();
    }
}