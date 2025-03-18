using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using MediatR;

namespace AcoTerra.Core.Features.Trailers.UpdateTrailer;

public sealed record UpdateTrailerCommand(
    int Id,
    string? LicensePlate,
    decimal? Capacity
) : ICommand<Unit>;


internal sealed class UpdateTrailerCommandHandler(
    IApplicationDbContext dbContext,
    TrailerService service
) : IRequestHandler<UpdateTrailerCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTrailerCommand request, CancellationToken cancellationToken)
    {
        Trailer trailer = await service.FindTrailerAsync(request.Id, cancellationToken);

        if (!string.IsNullOrWhiteSpace(request.LicensePlate))
        {
            trailer.LicensePlate = request.LicensePlate;
        }

        if (request.Capacity.HasValue)
        {
            trailer.Capacity = request.Capacity.Value;
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}