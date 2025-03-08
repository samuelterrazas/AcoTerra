using AcoTerra.Core.Entities.LegalDocuments.Enums;

namespace AcoTerra.Core.Entities.LegalDocuments;

public sealed class LegalDocument : AuditableEntity
{
    public int Id { get; set; }
    public int? VehicleId { get; set; }
    public int? AgentId { get; set; }
    public required LegalDocumentType Type { get; set; }
    public required string Document { get; set; }
    public DateOnly? ExpirationDate { get; set; }
}