using AcoTerra.Core.Entities.Products;

namespace AcoTerra.Core.Features.Products.SearchProducts;

public sealed record ProductResponse(
    int Id,
    string Name,
    string PackagingType,
    decimal Weight,
    decimal Price
)
{
    public static explicit operator ProductResponse(Product product)
    {
        return new ProductResponse(
            Id: product.Id,
            Name: product.Name,
            PackagingType: Enum.GetName(product.PackagingType)!,
            Weight: product.Weight,
            Price: product.Price
        );
    }
}