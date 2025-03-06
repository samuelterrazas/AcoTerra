using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Freights.CreateShipment;

public sealed record CreateShipmentCommand(
    int FreightId,
    int ProducerId,
    int ProductId,
    decimal Quantity,
    int CustomerId,
    string Location
) : ICommand;