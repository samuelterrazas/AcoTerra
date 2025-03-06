using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Products;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Products.SearchProducts;

internal sealed class SearchProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);

    private static async Task<Ok<List<ProductResponse>>> Handle(
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        List<ProductResponse> products = await dbContext
            .EntitySetFor<Product>()
            .Select(product => (ProductResponse)product)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        
        return TypedResults.Ok(products);
    }
}