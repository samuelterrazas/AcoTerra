using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trailers;

internal sealed class TrailerService(IApplicationDbContext dbContext)
{
    public async Task<Trailer> FindTrailerAsync(int id, CancellationToken cancellationToken)
    {
        Trailer? trailer = await dbContext
            .EntitySetFor<Trailer>()
            .FirstOrDefaultAsync(trailer => trailer.Id == id, cancellationToken);

        if (trailer is null)
        {
            throw new NotFoundException();
        }

        return trailer;
    }
}