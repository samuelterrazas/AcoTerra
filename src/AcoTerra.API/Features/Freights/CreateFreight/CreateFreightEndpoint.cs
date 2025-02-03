using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Freights;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Freights.CreateFreight;

internal sealed class CreateFreightEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", Handle);

    private static async Task<Created<int>> Handle(
        CreateFreightRequest request,
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        if (request.LoadingDate > request.UnloadingDate)
        {
            throw new InvalidOperationException();
        }
        
        string lastFreightNumber = await GetLastFreightNumberAsync(dbContext, cancellationToken);

        var freight = new Freight
        {
            Number = lastFreightNumber,
            VehicleId = request.VehicleId,
            EmployeeId = request.EmployeeId,
            LoadingDate = request.LoadingDate,
            UnloadingDate = request.UnloadingDate,
            Remarks = request.Remarks,
        };

        dbContext.EntitySetFor<Freight>().Add(freight);

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"/freights/{freight.Id}", freight.Id);
    }

    private static async Task<string> GetLastFreightNumberAsync(
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        string lastFreightNumberString = await dbContext.EntitySetFor<Freight>()
            .MaxAsync(i => i.Number.Trim('F'), cancellationToken);

        _ = int.TryParse(lastFreightNumberString, out int lastFreightNumber);

        return $"F{lastFreightNumber + 1}";
    }
}