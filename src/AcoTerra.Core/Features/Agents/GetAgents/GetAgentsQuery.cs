using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Agents.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents.GetAgents;

public sealed record GetAgentsQuery(AgentType Type) : IQuery<List<AgentListDto>>;


internal sealed class GetAgentsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetAgentsQuery, List<AgentListDto>>
{
    public async Task<List<AgentListDto>> Handle(GetAgentsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Agent>()
            .Where(agent => agent.Type == request.Type)
            .Select(agent => AgentListDto.Map(agent))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}