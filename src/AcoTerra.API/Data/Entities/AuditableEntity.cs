namespace AcoTerra.API.Data.Entities;

internal abstract class AuditableEntity
{
    public DateTime LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
}