using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Freights;
using AcoTerra.Core.Entities.Freights.Enums;
using AcoTerra.Core.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Freights.CreateShipment;

internal sealed class CreateShipmentCommandHandler(
    IApplicationDbContext dbContext,
    IMediator mediator
) : ICommandHandler<CreateShipmentCommand>
{
    public async Task Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        string lastShipmentNumber = await GetLastShipmentNumberAsync(
            request.FreightId,
            dbContext,
            cancellationToken
        );
        
        Product product = await dbContext
            .EntitySetFor<Product>()
            .FirstAsync(product => product.Id == request.ProductId, cancellationToken);

        decimal totalProductQuantity = request.Quantity;
        decimal totalProductWeight = product.Weight * totalProductQuantity;
        decimal totalProductAmount = product.Price * totalProductQuantity;

        var shipment = new Shipment
        {
            FreightId = request.FreightId,
            Number = lastShipmentNumber,
            ProducerId = request.ProducerId,
            ProductId = request.ProductId,
            TotalProductQuantity = totalProductQuantity,
            TotalProductWeight = totalProductWeight,
            TotalProductAmount = totalProductAmount,
            CustomerId = request.CustomerId,
            Location = request.Location,
            Status = ShipmentStatus.Pending,
        };
        
        dbContext.EntitySetFor<Shipment>().Add(shipment);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        await mediator.Publish(new ShipmentCreatedEvent(shipment.Id), cancellationToken);
    }
    
    private static async Task<string> GetLastShipmentNumberAsync(
        int freightId,
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        string lastShipmentNumberString = await dbContext
            .EntitySetFor<Shipment>()
            .Where(shipment => shipment.FreightId == freightId)
            .MaxAsync(shipment => shipment.Number.Trim('E'), cancellationToken);

        _ = int.TryParse(lastShipmentNumberString, out int lastShipmentNumber);

        return $"E{lastShipmentNumber + 1}";
    }
}