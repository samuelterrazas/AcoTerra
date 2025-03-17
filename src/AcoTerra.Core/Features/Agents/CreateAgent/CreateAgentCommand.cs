using System.Text.Json;
using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.DTOs;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents.CreateAgent;

public sealed record CreateAgentCommand(
    AgentType Type,
    string Name,
    IdentificationType IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string Email,
    EmploymentStatus? EmploymentStatus,
    DateOnly? DateOfBirth,
    EmergencyContactDto? EmergencyContact
) : ICommand<int>;


internal sealed class CreateAgentCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<CreateAgentCommand, int>
{
    public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
    {
        bool agentExists = await dbContext
            .EntitySetFor<Agent>()
            .AnyAsync(agent => agent.IdentificationNumber == request.IdentificationNumber, cancellationToken);

        if (agentExists)
        {
            throw new ResourceAlreadyExistsException();
        }
        
        Agent agent = InitializeAgent(request);
        
        dbContext.EntitySetFor<Agent>().Add(agent);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return agent.Id;
    }
    
    private static Agent InitializeAgent(CreateAgentCommand request)
    {
        string? emergencyContact = request.EmergencyContact is not null
            ? JsonSerializer.Serialize(request.EmergencyContact, JsonSerializerOptions.Web)
            : null;
        
        return request.Type switch
        {
            AgentType.Driver => new Driver
            {
                Name = request.Name,
                IdentificationType = request.IdentificationType,
                IdentificationNumber = request.IdentificationNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                EmploymentStatus = request.EmploymentStatus.GetValueOrDefault(),
                DateOfBirth = request.DateOfBirth.GetValueOrDefault(),
                EmergencyContact = emergencyContact,
            },
            AgentType.Producer => new Producer
            {
                Name = request.Name,
                IdentificationType = request.IdentificationType,
                IdentificationNumber = request.IdentificationNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            },
            AgentType.Customer => new Customer
            {
                Name = request.Name,
                IdentificationType = request.IdentificationType,
                IdentificationNumber = request.IdentificationNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            },
            _ => throw new ArgumentOutOfRangeException(nameof(request.Type)),
        };
    }
}