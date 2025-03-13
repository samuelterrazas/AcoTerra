using AcoTerra.Core.Features.Trailers.SearchTrailers;
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

        groupBuilder.MapGet("/", SearchTrailers);
        // groupBuilder.MapGet("{id:int}", );
        // groupBuilder.MapPost("/", );
        // groupBuilder.MapPut("{id:int}", );
        // groupBuilder.MapDelete("{id:int}", );
    }
    
    private static async Task<Ok<List<TrailerSearchResultDto>>> SearchTrailers(
        string? licensePlate,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var query = new SearchTrailersQuery(licensePlate);
        List<TrailerSearchResultDto> result = await sender.Send(query, cancellationToken);
        
        return TypedResults.Ok(result);
    }
}