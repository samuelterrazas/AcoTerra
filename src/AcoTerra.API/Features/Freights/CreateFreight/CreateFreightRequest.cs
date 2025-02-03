namespace AcoTerra.API.Features.Freights.CreateFreight;

internal sealed record CreateFreightRequest(
    int VehicleId,
    int EmployeeId,
    DateOnly LoadingDate,
    DateOnly UnloadingDate,
    string? Remarks
);