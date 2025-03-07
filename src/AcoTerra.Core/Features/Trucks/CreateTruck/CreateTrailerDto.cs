namespace AcoTerra.Core.Features.Trucks.CreateTruck;

public sealed record CreateTrailerDto(
    string LicensePlate,
    decimal Capacity
);