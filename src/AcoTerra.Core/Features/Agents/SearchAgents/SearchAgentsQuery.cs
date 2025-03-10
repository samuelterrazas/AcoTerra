using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents.SearchAgents;

public sealed record SearchAgentsQuery(AgentType Type) : IQuery<List<AgentResponse>>;


internal sealed class SearchAgentsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchAgentsQuery, List<AgentResponse>>
{
    public async Task<List<AgentResponse>> Handle(SearchAgentsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Agent>()
            .Where(agent => agent.Type == request.Type)
            .Select(agent => AgentResponse.Map(agent))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}