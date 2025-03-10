using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents.SearchAgents;

public sealed record SearchAgentsQuery(
    AgentType Type,
    string Name
) : IQuery<List<AgentSearchResultDto>>;


internal sealed class SearchAgentsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchAgentsQuery, List<AgentSearchResultDto>>
{
    public async Task<List<AgentSearchResultDto>> Handle(SearchAgentsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Agent> agents = dbContext
            .EntitySetFor<Agent>()
            .Where(agent => agent.Type == request.Type)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            agents = agents.Where(agent => agent.Name.Contains(request.Name));
        }

        return await agents
            .Select(agent => AgentSearchResultDto.Map(agent))
            .ToListAsync(cancellationToken);
    }
}