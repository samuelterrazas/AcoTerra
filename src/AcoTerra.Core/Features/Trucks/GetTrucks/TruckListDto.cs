using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Trucks.GetTrucks;

public sealed record TruckListDto(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber
)
{
    public static explicit operator TruckListDto(Truck truck)
    {
        return new TruckListDto(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            ManufacturingYear: truck.ManufacturingYear,
            ChassisNumber: truck.ChassisNumber,
            EngineNumber: truck.EngineNumber
        );
    }
}