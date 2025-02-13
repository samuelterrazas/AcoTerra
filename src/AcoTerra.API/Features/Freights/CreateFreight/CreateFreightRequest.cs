namespace AcoTerra.API.Features.Freights.CreateFreight;

internal sealed record CreateFreightRequest(
    int TruckId,
    DateOnly LoadingDate,
    DateOnly UnloadingDate,
    string? Remarks
);