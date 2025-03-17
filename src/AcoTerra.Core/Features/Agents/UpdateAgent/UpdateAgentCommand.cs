using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;
using MediatR;

namespace AcoTerra.Core.Features.Agents.UpdateAgent;

public sealed record UpdateAgentCommand(
    int Id,
    string? Name,
    IdentificationType? IdentificationType,
    string? IdentificationNumber,
    string? PhoneNumber,
    string? Email,
    EmploymentStatus? EmploymentStatus,
    DateOnly? DateOfBirth
) : ICommand<Unit>;


internal sealed class UpdateAgentCommandHandler(
    IApplicationDbContext dbContext,
    AgentService service
) : ICommandHandler<UpdateAgentCommand, Unit>
{
    public async Task<Unit> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
    {
        Agent agent = await service.FindAgentAsync(request.Id, cancellationToken);
        
        UpdateAgentFields(agent, request);

        if (agent is Driver driver)
        {
            UpdateDriverFields(driver, request);
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }

    private static void UpdateAgentFields(Agent agent, UpdateAgentCommand request)
    {
        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            agent.Name = request.Name!;
        }
        
        if (request.IdentificationType.HasValue)
        {
            agent.IdentificationType = request.IdentificationType.Value;
        }

        if (!string.IsNullOrWhiteSpace(request.IdentificationNumber))
        {
            agent.IdentificationNumber = request.IdentificationNumber;
        }

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            agent.PhoneNumber = request.PhoneNumber;
        }

        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            agent.Email = request.Email;
        }
    }

    private static void UpdateDriverFields(Driver driver, UpdateAgentCommand request)
    {
        if (request.EmploymentStatus.HasValue)
        {
            driver.EmploymentStatus = request.EmploymentStatus.Value;
        }

        if (request.DateOfBirth.HasValue)
        {
            driver.DateOfBirth = request.DateOfBirth.Value;
        }
    }
}