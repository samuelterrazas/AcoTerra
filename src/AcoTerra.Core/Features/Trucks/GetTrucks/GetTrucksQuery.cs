using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.GetTrucks;

public sealed record GetTrucksQuery : IQuery<List<TruckListDto>>;


internal sealed class GetTrucksQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetTrucksQuery, List<TruckListDto>>
{
    public async Task<List<TruckListDto>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Truck>()
            .AsNoTracking()
            .Select(truck => (TruckListDto)truck)
            .ToListAsync(cancellationToken);
    }
}