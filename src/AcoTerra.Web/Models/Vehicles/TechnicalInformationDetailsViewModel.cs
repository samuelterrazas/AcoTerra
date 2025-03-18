namespace AcoTerra.Web.Models.Vehicles;

public sealed class TechnicalInformationDetailsViewModel
{
    public decimal CurrentMileage { get; init; }
    public string FuelType { get; init; }
    public decimal AverageConsumption { get; init; }
    public decimal TankSize { get; init; }
}