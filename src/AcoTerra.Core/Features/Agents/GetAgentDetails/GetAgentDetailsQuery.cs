using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Agents;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents.GetAgentDetails;

public sealed record GetAgentDetailsQuery(int Id) : IQuery<AgentDetailsDto>;


internal sealed class GetAgentDetailsQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetAgentDetailsQuery, AgentDetailsDto>
{
    public async Task<AgentDetailsDto> Handle(GetAgentDetailsQuery request, CancellationToken cancellationToken)
    {
        Agent? agent = await dbContext
            .EntitySetFor<Agent>()
            .AsNoTracking()
            .FirstOrDefaultAsync(agent => agent.Id == request.Id, cancellationToken);

        if (agent is null)
        {
            throw new NotFoundException();
        }
        
        return AgentDetailsDto.Map(agent);
    }
}