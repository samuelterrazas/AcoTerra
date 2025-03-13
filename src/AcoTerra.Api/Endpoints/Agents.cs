using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Features.Agents.GetAgents;
using AcoTerra.Core.Features.Agents.SearchDrivers;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Api.Endpoints;

internal static class Agents
{
    public static void MapAgentEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder groupBuilder = app
            .MapGroup("/api/agents")
            .WithTags(nameof(Agents));

        groupBuilder.MapGet("/", GetAgents);
        groupBuilder.MapGet("/drivers", SearchDrivers);
        // groupBuilder.MapPost("/", );
        // groupBuilder.MapPut("{id:int}", );
        // groupBuilder.MapDelete("{id:int}", );
    }
    
    private static async Task<Ok<List<AgentListDto>>> GetAgents(
        AgentType type,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var query = new GetAgentsQuery(type);
        List<AgentListDto> result = await sender.Send(query, cancellationToken);
        
        return TypedResults.Ok(result);
    }
    
    private static async Task<Ok<List<DriverSearchResultDto>>> SearchDrivers(
        string? name,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var query = new SearchDriversQuery(name);
        List<DriverSearchResultDto> result = await sender.Send(query, cancellationToken);
        
        return TypedResults.Ok(result);
    }
}