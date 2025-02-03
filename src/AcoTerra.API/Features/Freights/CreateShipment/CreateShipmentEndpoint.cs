using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Freights;
using AcoTerra.API.Data.Entities.Freights.Enums;
using AcoTerra.API.Data.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Freights.CreateShipment;

internal sealed class CreateShipmentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/{freightId:int}/shipments", Handle);

    private static async Task<Created<int>> Handle(
        int freightId,
        CreateShipmentRequest request,
        IApplicationDbContext dbContext,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        string lastShipmentNumber = await GetLastShipmentNumberAsync(
            freightId,
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
            FreightId = freightId,
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

        return TypedResults.Created($"/{shipment.FreightId}/shipments/{shipment.Id}", shipment.Id);
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