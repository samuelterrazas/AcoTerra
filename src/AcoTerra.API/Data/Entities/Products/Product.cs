using AcoTerra.API.Data.Entities.Products.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Products;

internal sealed class Product : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required PackagingType PackagingType { get; set; }
    public required double Weight { get; set; }
    public required decimal Price { get; set; }
}

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Id)
            .ValueGeneratedOnAdd();
    }
}