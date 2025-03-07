using AcoTerra.Core.Entities.Trucks;
using AcoTerra.Core.Features.Common.DTOs;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

internal sealed record TruckDetailsResponse(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    TechnicalInformationDto TechnicalInformation,
    FinancialInformationDto FinancialInformation,
    TrailerDto? Trailer
)
{
    public static explicit operator TruckDetailsResponse(Truck truck)
    {
        return new TruckDetailsResponse(
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
                : null
        );
    }
}