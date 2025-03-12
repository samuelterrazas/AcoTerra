using AcoTerra.Core.Entities.Vehicles;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

public sealed record TechnicalInformationDto(
    decimal CurrentMileage,
    string FuelType,
    decimal AverageConsumption,
    decimal TankSize
)
{
    public static explicit operator TechnicalInformationDto(TechnicalInformation technicalInfo)
    {
        return new TechnicalInformationDto(
            CurrentMileage: technicalInfo.CurrentMileage,
            FuelType: Enum.GetName(technicalInfo.FuelType)!,
            AverageConsumption: technicalInfo.AverageConsumption,
            TankSize: technicalInfo.TankSize
        );
    }
}