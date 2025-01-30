using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Trucks;

internal sealed class Trailer : AuditableEntity
{
    public int Id { get; set; }
    public int? TruckId { get; set; }
    public required string LicensePlate { get; set; }
    public double Capacity { get; set; }
}

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