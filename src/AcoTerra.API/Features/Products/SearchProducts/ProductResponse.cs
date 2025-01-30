using AcoTerra.API.Data.Entities.Products;

namespace AcoTerra.API.Features.Products.SearchProducts;

internal sealed record ProductResponse(
    int Id,
    string Name,
    string PackagingType,
    double Weight,
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