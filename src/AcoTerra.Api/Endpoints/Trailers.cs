using AcoTerra.Core.Features.Trailers.CreateTrailer;
using AcoTerra.Core.Features.Trailers.DeleteTrailer;
using AcoTerra.Core.Features.Trailers.GetTrailers;
using AcoTerra.Core.Features.Trailers.SearchTrailers;
using AcoTerra.Core.Features.Trailers.UpdateTrailer;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Api.Endpoints;

internal static class Trailers
{
    public static void MapTrailerEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder groupBuilder = app
            .MapGroup("/api/trailers")
            .WithTags(nameof(Trailers));
        
        groupBuilder.MapGet("/", GetTrailers);
        groupBuilder.MapPost("/", CreateTrailer);
        groupBuilder.MapPut("/{id:int}", UpdateTrailer);
        groupBuilder.MapDelete("{id:int}", DeleteTrailer);
        
        groupBuilder.MapGet("/search", SearchTrailers);
    }
    
    private static async Task<Ok<List<TrailerListDto>>> GetTrailers(
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new GetTrailersQuery();
        List<TrailerListDto> result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }

    private static async Task<Created<int>> CreateTrailer(
        CreateTrailerCommand request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        int result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Created($"/api/trailers/{result}", result);
    }

    private static async Task<NoContent> UpdateTrailer(
        int id,
        UpdateTrailerCommand request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        request = request with { Id = id };
        await sender.Send(request, cancellationToken);
        
        return TypedResults.NoContent();
    }

    private static async Task<NoContent> DeleteTrailer(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new DeleteTrailerCommand(id);
        await sender.Send(request, cancellationToken);
        
        return TypedResults.NoContent();
    }
    
    private static async Task<Ok<List<TrailerSearchResultDto>>> SearchTrailers(
        string? licensePlate,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new SearchTrailersQuery(licensePlate);
        List<TrailerSearchResultDto> result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }
}