using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents.Enums;

namespace AcoTerra.Core.Features.Agents.CreateAgent;

public sealed record CreateAgentCommand(
    string Name,
    IdentificationType IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string Email,
    EmploymentStatus EmploymentStatus,
    DateOnly DateOfBirth
) : ICommand;

// TODO: Falta implementar CreateDriverCommandHandler