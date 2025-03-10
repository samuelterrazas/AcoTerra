using AcoTerra.Core.Entities.Agents;

namespace AcoTerra.Core.Features.Agents.SearchAgents;

public sealed record AgentSearchResultDto(
    int Id,
    string Name,
    string IdentificationNumber
)
{
    internal static AgentSearchResultDto Map(Agent agent)
    {
        return agent switch
        {
            Driver driver => CreateAgentResponse(driver),
            Producer producer => CreateAgentResponse(producer),
            Customer customer => CreateAgentResponse(customer),
            _ => throw new ArgumentOutOfRangeException(nameof(agent)),
        };
    }

    private static AgentSearchResultDto CreateAgentResponse(Agent agent)
    {
        return new AgentSearchResultDto(
            Id: agent.Id,
            Name: agent.Name,
            IdentificationNumber: agent.IdentificationNumber
        );
    }
}