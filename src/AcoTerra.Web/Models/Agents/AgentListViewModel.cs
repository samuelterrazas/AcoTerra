using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Features.Agents.GetAgents;

namespace AcoTerra.Web.Models.Agents;

public sealed class AgentListViewModel
{
    public AgentType Type { get; init; }
    public List<AgentListDto> Agents { get; init; } = [];
}