using AcoTerra.API.Common.Abstractions;
using Bogus;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AcoTerra.API.Features.Products.SearchProducts;

internal sealed class SearchProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);

    private static Ok<List<ProductResponse>> Handle()
    {
        var products = new List<ProductResponse>();

        for (int i = 0; i < 10; i++)
        {
            var faker = new Faker("es");

            var product = new ProductResponse(
                Id: i + 1,
                Name: faker.Commerce.Product(),
                PackagingType: "Palé",
                Weight: double.Round(faker.Random.Double(min: 10, max: 1500), digits: 2),
                Price: decimal.Parse(faker.Commerce.Price())
            );
            
            products.Add(product);
        }

        return TypedResults.Ok(products);
    }
}