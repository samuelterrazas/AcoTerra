using AcoTerra.API.Data.Entities.Products;

namespace AcoTerra.API.Features.Products.SearchProducts;

internal sealed record ProductResponse(
    int Id,
    string Name,
    decimal PricePerPackage
)
{
    public static explicit operator ProductResponse(Product product)
    {
        return new ProductResponse(
            Id: product.Id,
            Name: product.Name,
            PricePerPackage: product.PricePerPackage
        );
    }
}