using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Entities.Drivers.Enums;

namespace AcoTerra.Core.Features.Drivers.CreateDriver;

public sealed record CreateDriverCommand(
    string Name,
    IdentificationType IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string Email,
    EmploymentStatus EmploymentStatus,
    DateOnly DateOfBirth
) : ICommand;

// TODO: Falta implementar CreateDriverCommandHandler