using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Products.GetProducts;

public sealed record GetProductsQuery : IQuery<List<ProductListDto>>;


internal sealed class GetProductsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetProductsQuery, List<ProductListDto>>
{
    public async Task<List<ProductListDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Product>()
            .Select(product => (ProductListDto)product)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}