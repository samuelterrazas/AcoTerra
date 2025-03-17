using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using MediatR;

namespace AcoTerra.Core.Features.Agents.DeleteAgent;

public sealed record DeleteAgentCommand(int Id) : ICommand<Unit>;


internal sealed class DeleteAgentCommandHandler(
    IApplicationDbContext dbContext,
    AgentService service
) : ICommandHandler<DeleteAgentCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAgentCommand request, CancellationToken cancellationToken)
    {
        Agent agent = await service.FindAgentAsync(request.Id, cancellationToken);

        if (agent is Driver { VehicleId: not null })
        {
            throw new InvalidOperationException("No se puede eliminar un conductor con un vehículo asignado.");
        }
        
        dbContext.EntitySetFor<Agent>().Remove(agent);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}