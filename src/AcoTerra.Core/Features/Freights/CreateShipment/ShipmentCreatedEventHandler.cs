using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Entities.Freights;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Freights.CreateShipment;

internal sealed class ShipmentCreatedEventHandler(
    IApplicationDbContext dbContext
) : INotificationHandler<ShipmentCreatedEvent>
{
    public async Task Handle(ShipmentCreatedEvent notification, CancellationToken cancellationToken)
    {
        Shipment? shipment = await dbContext
            .EntitySetFor<Shipment>()
            .FirstOrDefaultAsync(shipment => shipment.Id == notification.ShipmentId, cancellationToken);

        if (shipment is null)
        {
            return;
        }
        
        Freight freight = await dbContext
            .EntitySetFor<Freight>()
            .FirstAsync(freight => freight.Id == shipment.FreightId, cancellationToken);

        freight.TotalShipmentQuantity += shipment.TotalProductQuantity;
        freight.TotalShipmentWeight += shipment.TotalProductWeight;
        freight.TotalShipmentAmount += shipment.TotalProductAmount;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}