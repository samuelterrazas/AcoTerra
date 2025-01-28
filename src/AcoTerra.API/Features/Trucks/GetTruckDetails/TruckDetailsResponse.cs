using AcoTerra.API.Data.Entities.Trucks;

namespace AcoTerra.API.Features.Trucks.GetTruckDetails;

internal sealed record TruckDetailsResponse(
    Guid Id,
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    double CurrentMileage,
    string FuelType,
    double AverageConsumption,
    double TankSize,
    decimal PurchasePrice,
    bool Financed,
    int Installments,
    decimal OutstandingBalance
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
            CurrentMileage: truck.TechnicalInformation.CurrentMileage,
            FuelType: Enum.GetName(truck.TechnicalInformation.FuelType)!,
            AverageConsumption: truck.TechnicalInformation.AverageConsumption,
            TankSize: truck.TechnicalInformation.TankSize,
            PurchasePrice: truck.FinancialInformation.PurchasePrice,
            Financed: truck.FinancialInformation.Financed,
            Installments: truck.FinancialInformation.Installments,
            OutstandingBalance: truck.FinancialInformation.OutstandingBalance
        );
    }
}