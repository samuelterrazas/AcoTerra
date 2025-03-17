using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Agents;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents;

internal sealed class AgentService(IApplicationDbContext dbContext)
{
    public async Task<Agent> FindAgentAsync(int id, CancellationToken cancellationToken)
    {
        Agent? agent = await dbContext
            .EntitySetFor<Agent>()
            .FirstOrDefaultAsync(agent => agent.Id == id, cancellationToken);
        
        if (agent is null)
        {
            throw new NotFoundException();
        }

        return agent;
    }
}