using AcoTerra.Core.Entities.Vehicles.Enums;

namespace AcoTerra.Core.Entities.Vehicles;

public sealed class TechnicalInformation : AuditableEntity
{
    public int Id { get; set; }
    public decimal CurrentMileage { get; set; }
    public FuelType FuelType { get; set; }
    public decimal AverageConsumption { get; set; }
    public decimal TankSize { get; set; }
}