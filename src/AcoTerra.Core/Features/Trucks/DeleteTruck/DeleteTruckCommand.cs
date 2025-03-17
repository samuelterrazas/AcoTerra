using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Trucks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.DeleteTruck;

public sealed record DeleteTruckCommand(int Id) : ICommand<Unit>;


internal sealed class DeleteTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<DeleteTruckCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
    {
        Truck? truck = await dbContext.EntitySetFor<Truck>()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new NotFoundException();
        }

        dbContext.EntitySetFor<Truck>().Remove(truck);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}