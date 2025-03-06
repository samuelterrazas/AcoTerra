using AcoTerra.Core.Entities.Trucks;
using AcoTerra.Core.Entities.Vehicles;
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
    TechnicalInformationDto TechnicalInfo,
    FinancialInformationDto FinancialInfo,
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
            TechnicalInfo: (TechnicalInformationDto)truck.TechnicalInformation,
            FinancialInfo: (FinancialInformationDto)truck.FinancialInformation,
            Trailer: truck.Trailer is not null
                ? (TrailerDto)truck.Trailer
                : null
        );
    }
}

internal sealed record TechnicalInformationDto(
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

internal sealed record FinancialInformationDto(
    decimal PurchasePrice,
    bool Financed,
    int Installments,
    decimal OutstandingBalance
)
{
    public static explicit operator FinancialInformationDto(FinancialInformation financialInfo)
    {
        return new FinancialInformationDto(
            PurchasePrice: financialInfo.PurchasePrice,
            Financed: financialInfo.Financed,
            Installments: financialInfo.Installments,
            OutstandingBalance: financialInfo.OutstandingBalance
        );
    }
}