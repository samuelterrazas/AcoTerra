using AcoTerra.Core.Common.DTOs;
using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Freights.GetFreightDetails;

public sealed record TruckDto(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    DriverDto Driver,
    TrailerDto Trailer
)
{
    public static explicit operator TruckDto(Truck truck)
    {
        if (truck.Driver is null)
        {
            throw new InvalidOperationException($"The '{nameof(truck.Driver)}' entity has not been initialized.");
        }
        
        if (truck.Trailer is null)
        {
            throw new InvalidOperationException($"The '{nameof(truck.Trailer)}' entity has not been initialized.");
        }
        
        return new TruckDto(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            Driver: (DriverDto)truck.Driver,
            Trailer: (TrailerDto)truck.Trailer
        );
    }
}