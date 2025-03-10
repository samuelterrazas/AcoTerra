using AcoTerra.Core.Entities.Products;

namespace AcoTerra.Core.Features.Products.GetProducts;

public sealed record ProductListDto(
    int Id,
    string Name,
    string PackagingType,
    decimal Weight,
    decimal Price
)
{
    public static explicit operator ProductListDto(Product product)
    {
        return new ProductListDto(
            Id: product.Id,
            Name: product.Name,
            PackagingType: Enum.GetName(product.PackagingType)!,
            Weight: product.Weight,
            Price: product.Price
        );
    }
}