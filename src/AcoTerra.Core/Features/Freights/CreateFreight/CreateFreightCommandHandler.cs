using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Freights;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Freights.CreateFreight;

internal sealed class CreateFreightCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<CreateFreightCommand>
{
    public async Task Handle(CreateFreightCommand request, CancellationToken cancellationToken)
    {
        if (request.LoadingDate > request.UnloadingDate)
        {
            throw new InvalidOperationException();
        }
        
        string lastFreightNumber = await GetLastFreightNumberAsync(cancellationToken);

        var freight = new Freight
        {
            Number = lastFreightNumber,
            TruckId = request.TruckId,
            LoadingDate = request.LoadingDate,
            UnloadingDate = request.UnloadingDate,
            Remarks = request.Remarks,
        };

        dbContext.EntitySetFor<Freight>().Add(freight);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private async Task<string> GetLastFreightNumberAsync(CancellationToken cancellationToken)
    {
        string lastFreightNumberString = await dbContext.EntitySetFor<Freight>()
            .MaxAsync(i => i.Number.Trim('F'), cancellationToken);

        _ = int.TryParse(lastFreightNumberString, out int lastFreightNumber);

        return $"F{lastFreightNumber + 1}";
    }
}