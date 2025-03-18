using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using MediatR;

namespace AcoTerra.Core.Features.Trailers.CreateTrailer;

public sealed record CreateTrailerCommand(
    string LicensePlate,
    decimal Capacity
) : ICommand<int>;


internal sealed class CreateTrailerCommandHandler(
    IApplicationDbContext dbContext
) : IRequestHandler<CreateTrailerCommand, int>
{
    public async Task<int> Handle(CreateTrailerCommand request, CancellationToken cancellationToken)
    {
        var trailer = new Trailer
        {
            LicensePlate = request.LicensePlate,
            Capacity = request.Capacity,
        };
        
        dbContext.EntitySetFor<Trailer>().Add(trailer);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return trailer.Id;
    }
}