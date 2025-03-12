using AcoTerra.Core.Common.DTOs;
using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

public sealed record TruckDetailsDto(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    TechnicalInformationDto TechnicalInformation,
    FinancialInformationDto FinancialInformation,
    TrailerDto? Trailer,
    DriverDto? Driver
)
{
    public static explicit operator TruckDetailsDto(Truck truck)
    {
        return new TruckDetailsDto(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            ManufacturingYear: truck.ManufacturingYear,
            ChassisNumber: truck.ChassisNumber,
            EngineNumber: truck.EngineNumber,
            TechnicalInformation: (TechnicalInformationDto)truck.TechnicalInformation,
            FinancialInformation: (FinancialInformationDto)truck.FinancialInformation,
            Trailer: truck.Trailer is not null
                ? (TrailerDto)truck.Trailer
                : null,
            Driver: truck.Driver is not null
                ? (DriverDto)truck.Driver
                : null
        );
    }
}