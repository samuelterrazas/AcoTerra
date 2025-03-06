using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Freights;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Freights.GetFreightDetails;

internal sealed class GetFreightDetailsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetFreightDetailsQuery, FreightDetailsResponse>
{
    public async Task<FreightDetailsResponse> Handle(GetFreightDetailsQuery request, CancellationToken cancellationToken)
    {
        Freight? freight = await dbContext
            .EntitySetFor<Freight>()
            .Include(freight => freight.Truck)
            .ThenInclude(truck => truck.Driver)
            .Include(freight => freight.Truck)
            .ThenInclude(truck => truck.Trailer)
            .Include(freight => freight.Shipments)
            .ThenInclude(shipment => shipment.Producer)
            .Include(freight => freight.Shipments)
            .ThenInclude(shipment => shipment.Product)
            .Include(freight => freight.Shipments)
            .ThenInclude(shipment => shipment.Customer)
            .AsNoTracking()
            .FirstOrDefaultAsync(freight => freight.Id == request.Id, cancellationToken);

        if (freight is null)
        {
            throw new Exception("The requested resource was not found.");
        }

        return (FreightDetailsResponse)freight;
    }
}