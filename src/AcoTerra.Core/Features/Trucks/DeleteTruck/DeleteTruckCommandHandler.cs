using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.DeleteTruck;

internal sealed class DeleteTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<DeleteTruckCommand>
{
    public async Task Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
    {
        Truck? truck = await dbContext.EntitySetFor<Truck>()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .Include(truck => truck.Trailer)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new Exception("The requested resource could not be found.");
        }

        dbContext.EntitySetFor<Truck>().Remove(truck);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}