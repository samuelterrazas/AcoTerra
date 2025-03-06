using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.SearchTrucks;

internal sealed class SearchTrucksQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchTrucksQuery, List<TruckResponse>>
{
    public async Task<List<TruckResponse>> Handle(SearchTrucksQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Truck>()
            .AsNoTracking()
            .Select(truck => (TruckResponse)truck)
            .ToListAsync(cancellationToken);
    }
}