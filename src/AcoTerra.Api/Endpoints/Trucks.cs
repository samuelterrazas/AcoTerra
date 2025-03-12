using AcoTerra.Core.Features.Trucks.CreateTruck;
using AcoTerra.Core.Features.Trucks.DeleteTruck;
using AcoTerra.Core.Features.Trucks.GetTruckDetails;
using AcoTerra.Core.Features.Trucks.GetTrucks;
using AcoTerra.Core.Features.Trucks.UpdateTruck;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Api.Endpoints;

internal static class Trucks
{
    public static void MapTruckEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder groupBuilder = app
            .MapGroup("/api/trucks")
            .WithTags(nameof(Trucks));

        groupBuilder.MapGet("/", GetTrucks);
        groupBuilder.MapGet("{id:int}", GetTruckDetails);
        groupBuilder.MapPost("/", CreateTruck);
        groupBuilder.MapPut("{id:int}", UpdateTruck);
        groupBuilder.MapDelete("{id:int}", DeleteTruck);
    }
    
    private static async Task<Ok<List<TruckListDto>>> GetTrucks(
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var query = new GetTrucksQuery();
        List<TruckListDto> trucks = await sender.Send(query, cancellationToken);
        
        return TypedResults.Ok(trucks);
    }

    private static async Task<Ok<TruckDetailsDto>> GetTruckDetails(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var query = new GetTruckDetailsQuery(id);
        TruckDetailsDto truckDetails = await sender.Send(query, cancellationToken);
        
        return TypedResults.Ok(truckDetails);
    }
    
    private static async Task<Created> CreateTruck(
        CreateTruckCommand command,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        await sender.Send(command, cancellationToken);
        
        return TypedResults.Created();
    }

    private static async Task<NoContent> UpdateTruck(
        int id,
        UpdateTruckCommand command,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        command = command with { Id = id };
        await sender.Send(command, cancellationToken);
        
        return TypedResults.NoContent();
    }

    private static async Task<NoContent> DeleteTruck(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteTruckCommand(id);
        await sender.Send(command, cancellationToken);
        
        return TypedResults.NoContent();
    }
}