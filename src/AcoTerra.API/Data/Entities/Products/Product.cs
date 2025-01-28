using AcoTerra.API.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Products;

public sealed class Product : AuditableEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal PricePerPackage { get; set; }
}

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Id)
            .ValueGeneratedNever();
    }
}