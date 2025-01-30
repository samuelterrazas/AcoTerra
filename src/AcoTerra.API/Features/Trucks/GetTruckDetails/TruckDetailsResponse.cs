using AcoTerra.API.Data.Entities.Trucks;
using AcoTerra.API.Data.Entities.Vehicles;

namespace AcoTerra.API.Features.Trucks.GetTruckDetails;

internal sealed record TruckDetailsResponse(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    TechnicalInformationResponse TechnicalInfo,
    FinancialInformationResponse FinancialInfo,
    TrailerResponse? Trailer
)
{
    public static explicit operator TruckDetailsResponse(Truck truck)
    {
        TechnicalInformation technicalInfo = truck.TechnicalInformation;
        FinancialInformation financialInfo = truck.FinancialInformation;
        Trailer? trailer = truck.Trailer;
        
        return new TruckDetailsResponse(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            ManufacturingYear: truck.ManufacturingYear,
            ChassisNumber: truck.ChassisNumber,
            EngineNumber: truck.EngineNumber,
            TechnicalInfo: new TechnicalInformationResponse(
                CurrentMileage: technicalInfo.CurrentMileage,
                FuelType: Enum.GetName(technicalInfo.FuelType)!,
                AverageConsumption: technicalInfo.AverageConsumption,
                TankSize: technicalInfo.TankSize
            ),
            FinancialInfo: new FinancialInformationResponse(
                PurchasePrice: financialInfo.PurchasePrice,
                Financed: financialInfo.Financed,
                Installments: financialInfo.Installments,
                OutstandingBalance: financialInfo.OutstandingBalance
            ),
            Trailer: trailer is not null
                ? new TrailerResponse(
                    Id: trailer.Id,
                    LicensePlate: trailer.LicensePlate,
                    Capacity: trailer.Capacity
                )
                : null
        );
    }
}

internal sealed record TechnicalInformationResponse(
    double CurrentMileage,
    string FuelType,
    double AverageConsumption,
    double TankSize
);

internal sealed record FinancialInformationResponse(
    decimal PurchasePrice,
    bool Financed,
    int Installments,
    decimal OutstandingBalance
);

internal sealed record TrailerResponse(
    int Id,
    string LicensePlate,
    double Capacity
);