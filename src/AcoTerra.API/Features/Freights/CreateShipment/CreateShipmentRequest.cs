namespace AcoTerra.API.Features.Freights.CreateShipment;

internal sealed record CreateShipmentRequest(
    int ProducerId,
    int ProductId,
    decimal Quantity,
    int CustomerId,
    string Location
);