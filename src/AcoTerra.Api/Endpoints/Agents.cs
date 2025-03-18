using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Features.Agents.CreateAgent;
using AcoTerra.Core.Features.Agents.DeleteAgent;
using AcoTerra.Core.Features.Agents.GetAgentDetails;
using AcoTerra.Core.Features.Agents.GetAgents;
using AcoTerra.Core.Features.Agents.SearchDrivers;
using AcoTerra.Core.Features.Agents.UpdateAgent;
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
        groupBuilder.MapGet("/{id:int}", GetAgentDetails);
        groupBuilder.MapPost("/", CreateAgent);
        groupBuilder.MapPut("{id:int}", UpdateAgent);
        groupBuilder.MapDelete("{id:int}", DeleteAgent);
        
        groupBuilder.MapGet("/drivers/search", SearchDrivers);
    }
    
    private static async Task<Ok<List<AgentListDto>>> GetAgents(
        AgentType type,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new GetAgentsQuery(type);
        List<AgentListDto> result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }

    private static async Task<Ok<AgentDetailsDto>> GetAgentDetails(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new GetAgentDetailsQuery(id);
        AgentDetailsDto result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }

    private static async Task<Created<int>> CreateAgent(
        CreateAgentCommand request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        int result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Created($"/api/agents/{result}", result);
    }

    private static async Task<NoContent> UpdateAgent(
        int id,
        UpdateAgentCommand request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        request = request with { Id = id };
        await sender.Send(request, cancellationToken);
        
        return TypedResults.NoContent();
    }

    private static async Task<NoContent> DeleteAgent(
        int id,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new DeleteAgentCommand(id);
        await sender.Send(request, cancellationToken);
        
        return TypedResults.NoContent();
    }
    
    private static async Task<Ok<List<DriverSearchResultDto>>> SearchDrivers(
        string? name,
        [FromServices] ISender sender,
        CancellationToken cancellationToken
    )
    {
        var request = new SearchDriversQuery(name);
        List<DriverSearchResultDto> result = await sender.Send(request, cancellationToken);
        
        return TypedResults.Ok(result);
    }
}