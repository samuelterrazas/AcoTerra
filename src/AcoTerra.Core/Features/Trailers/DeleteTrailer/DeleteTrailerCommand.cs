using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using MediatR;

namespace AcoTerra.Core.Features.Trailers.DeleteTrailer;

public sealed record DeleteTrailerCommand(int Id) : ICommand<Unit>;


internal sealed class DeleteTrailerCommandHandler(
    IApplicationDbContext dbContext,
    TrailerService service
) : IRequestHandler<DeleteTrailerCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTrailerCommand request, CancellationToken cancellationToken)
    {
        Trailer trailer = await service.FindTrailerAsync(request.Id, cancellationToken);

        if (trailer.TruckId is not null)
        {
            throw new InvalidOperationException("No se puede eliminar un trailer con un camión asignado.");
        }
        
        dbContext.EntitySetFor<Trailer>().Remove(trailer);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}