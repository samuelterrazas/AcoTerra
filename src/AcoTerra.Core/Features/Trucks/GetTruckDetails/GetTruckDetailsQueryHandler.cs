using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

internal sealed class GetTruckDetailsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetTruckDetailsQuery, TruckDetailsResponse>
{
    public async Task<TruckDetailsResponse> Handle(GetTruckDetailsQuery request, CancellationToken cancellationToken)
    {
        Truck? truck = await dbContext
            .EntitySetFor<Truck>()
            .AsNoTracking()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .Include(truck => truck.Trailer)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new Exception("The requested resource could not be found.");
        }

        return (TruckDetailsResponse)truck;
    }
}