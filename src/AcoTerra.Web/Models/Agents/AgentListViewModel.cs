using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Features.Agents.SearchAgents;

namespace AcoTerra.Web.Models.Agents;

public sealed class AgentListViewModel
{
    public AgentType Type { get; init; }
    public List<AgentResponse> Agents { get; init; } = [];
}