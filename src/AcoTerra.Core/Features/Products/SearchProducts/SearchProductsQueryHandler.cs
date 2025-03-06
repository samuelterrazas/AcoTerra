using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Products.SearchProducts;

internal sealed class SearchProductsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchProductsQuery, List<ProductResponse>>
{
    public async Task<List<ProductResponse>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Product>()
            .Select(product => (ProductResponse)product)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}