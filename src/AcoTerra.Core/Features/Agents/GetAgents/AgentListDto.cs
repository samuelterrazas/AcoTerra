using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;

namespace AcoTerra.Core.Features.Agents.GetAgents;

public sealed record AgentListDto(
    int Id,
    AgentType Type,
    string Name,
    string PhoneNumber,
    string? Email,
    string? EmploymentStatus
)
{
    internal static AgentListDto Map(Agent agent)
    {
        return agent switch
        {
            Driver driver => CreateAgentResponse(
                agent: driver,
                employmentStatus: Enum.GetName(driver.EmploymentStatus)
            ),
            Producer producer => CreateAgentResponse(producer),
            Customer customer => CreateAgentResponse(customer),
            _ => throw new ArgumentOutOfRangeException(nameof(agent)),
        };
    }

    private static AgentListDto CreateAgentResponse(
        Agent agent,
        string? employmentStatus = null
    )
    {
        return new AgentListDto(
            Id: agent.Id,
            Type: agent.Type,
            Name: agent.Name,
            PhoneNumber: agent.PhoneNumber,
            Email: agent.Email,
            EmploymentStatus: employmentStatus
        );
    }
}