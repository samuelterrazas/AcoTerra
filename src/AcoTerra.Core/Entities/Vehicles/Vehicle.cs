using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.LegalDocuments;
using AcoTerra.Core.Entities.Vehicles.Enums;

namespace AcoTerra.Core.Entities.Vehicles;

public abstract class Vehicle : AuditableEntity
{
    public int Id { get; set; }
    public VehicleType Type { get; set; }
    public required string LicensePlate { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required int ManufacturingYear { get; set; }
    public required string ChassisNumber { get; set; }
    public required string EngineNumber { get; set; }

    public TechnicalInformation TechnicalInformation { get; set; } = new();
    public FinancialInformation FinancialInformation { get; set; } = new();
    public ICollection<LegalDocument> LegalDocuments { get; set; } = [];
    public ICollection<MaintenanceHistory> MaintenanceHistory { get; set; } = [];
    public ICollection<TrafficFine> TrafficFines { get; set; } = [];
    public ICollection<AdditionalEquipment> AdditionalEquipment { get; set; } = [];
    public Driver? Driver { get; set; }
}