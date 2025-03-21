﻿using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Entities.LegalDocuments;

namespace AcoTerra.Core.Entities.Agents;

public abstract class Agent : AuditableEntity
{
    public int Id { get; set; }
    public AgentType Type { get; set; }
    public required string Name { get; set; }
    public required IdentificationType IdentificationType { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }

    public ICollection<LegalDocument> LegalDocuments { get; set; } = [];
}