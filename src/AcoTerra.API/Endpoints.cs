﻿using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Features.Trucks.CreateTruck;
using AcoTerra.API.Features.Trucks.GetTruckDetails;
using AcoTerra.API.Features.Trucks.SearchTrucks;

namespace AcoTerra.API;

internal static class Endpoints
{
    internal static void MapEndpoints(this WebApplication app)
    {
        app.MapTruckEndpoints();
    }

    private static void MapTruckEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/trucks")
            .WithTags("Trucks");

        routeGroup
            .Map<SearchTrucksEndpoint>()
            .Map<GetTruckDetailsEndpoint>()
            .Map<CreateTruckEndpoint>();
    }

    private static IEndpointRouteBuilder Map<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);

        return app;
    }
}