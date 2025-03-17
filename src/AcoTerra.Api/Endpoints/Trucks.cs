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
        groupBuilder.MapGet("/{id:int}", GetTruckDetails);
        groupBuilder.MapPost("/", CreateTruck);
        groupBuilder.MapPut("/{id:int}", UpdateTruck);
        groupBuilder.MapDelete("/{id:int}", DeleteTruck);
    }
    
    private static async Task<Ok<List<TruckListDto>>> GetTrucks(
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new GetTrucksQuery();
        List<TruckListDto> result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }

    private static async Task<Ok<TruckDetailsDto>> GetTruckDetails(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new GetTruckDetailsQuery(id);
        TruckDetailsDto result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }
    
    private static async Task<Created> CreateTruck(
        CreateTruckCommand request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        await sender.Send(request, cancellationToken);
        
        return TypedResults.Created();
    }

    private static async Task<NoContent> UpdateTruck(
        int id,
        UpdateTruckCommand request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        request = request with { Id = id };
        await sender.Send(request, cancellationToken);
        
        return TypedResults.NoContent();
    }

    private static async Task<NoContent> DeleteTruck(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new DeleteTruckCommand(id);
        await sender.Send(request, cancellationToken);
        
        return TypedResults.NoContent();
    }
}