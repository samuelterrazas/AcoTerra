using AcoTerra.Core.Entities.Vehicles.Enums;

namespace AcoTerra.Core.Entities.Vehicles;

public sealed class AdditionalEquipment : AuditableEntity
{
    public int Id { get; set; }
    public required int VehicleId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Cost { get; set; }
    public required EquipmentCondition Condition { get; set; }
}