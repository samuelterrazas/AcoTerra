using AcoTerra.Core.Entities.Agents;

namespace AcoTerra.Core.Features.Agents.GetAgents;

public sealed record AgentListDto(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email,
    string? EmploymentStatus,
    DateOnly? DateOfBirth
)
{
    internal static AgentListDto Map(Agent agent)
    {
        return agent switch
        {
            Driver driver => CreateAgentResponse(
                agent: driver,
                employmentStatus: Enum.GetName(driver.EmploymentStatus)!,
                dateOfBirth: driver.DateOfBirth
            ),
            Producer producer => CreateAgentResponse(producer),
            Customer customer => CreateAgentResponse(customer),
            _ => throw new ArgumentOutOfRangeException(nameof(agent)),
        };
    }

    private static AgentListDto CreateAgentResponse(
        Agent agent,
        string? employmentStatus = null,
        DateOnly? dateOfBirth = null
    )
    {
        return new AgentListDto(
            Id: agent.Id,
            Name: agent.Name,
            IdentificationType: Enum.GetName(agent.IdentificationType)!,
            IdentificationNumber: agent.IdentificationNumber,
            PhoneNumber: agent.PhoneNumber,
            Email: agent.Email,
            EmploymentStatus: employmentStatus,
            DateOfBirth: dateOfBirth
        );
    }
}