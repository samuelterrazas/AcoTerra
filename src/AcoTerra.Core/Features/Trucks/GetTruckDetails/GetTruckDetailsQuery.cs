using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

public sealed record GetTruckDetailsQuery(int Id) : IQuery<TruckDetailsDto>;


internal sealed class GetTruckDetailsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetTruckDetailsQuery, TruckDetailsDto>
{
    public async Task<TruckDetailsDto> Handle(GetTruckDetailsQuery request, CancellationToken cancellationToken)
    {
        Truck? truck = await dbContext
            .EntitySetFor<Truck>()
            .AsNoTracking()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .Include(truck => truck.Trailer)
            .Include(truck => truck.Driver)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new NotFoundException();
        }

        return (TruckDetailsDto)truck;
    }
}