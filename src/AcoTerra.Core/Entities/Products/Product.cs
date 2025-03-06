using AcoTerra.Core.Entities.Products.Enums;

namespace AcoTerra.Core.Entities.Products;

public sealed class Product : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required PackagingType PackagingType { get; set; }
    public required decimal Weight { get; set; }
    public required decimal Price { get; set; }
}