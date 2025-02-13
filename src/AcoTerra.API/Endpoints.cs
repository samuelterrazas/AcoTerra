using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Features.Customers.SearchCustomers;
using AcoTerra.API.Features.Drivers.SearchDrivers;
using AcoTerra.API.Features.Freights.CreateFreight;
using AcoTerra.API.Features.Freights.CreateShipment;
using AcoTerra.API.Features.Freights.GetFreightDetails;
using AcoTerra.API.Features.Producers.SearchProducers;
using AcoTerra.API.Features.Products.SearchProducts;
using AcoTerra.API.Features.Trucks.CreateTruck;
using AcoTerra.API.Features.Trucks.DeleteTruck;
using AcoTerra.API.Features.Trucks.GetTruckDetails;
using AcoTerra.API.Features.Trucks.SearchTrucks;
using AcoTerra.API.Features.Trucks.UpdateTruck;

namespace AcoTerra.API;

internal static class Endpoints
{
    internal static void MapEndpoints(this WebApplication app)
    {
        app.MapFreightEndpoints();
        app.MapTruckEndpoints();
        app.MapDriverEndpoints();
        app.MapProducerEndpoints();
        app.MapProductEndpoints();
        app.MapCustomerEndpoints();
    }

    private static void MapFreightEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/freights")
            .WithTags("Freights");

        routeGroup
            .Map<GetFreightDetailsEndpoint>()
            .Map<CreateFreightEndpoint>()
            .Map<CreateShipmentEndpoint>();
    }

    private static void MapTruckEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/trucks")
            .WithTags("Trucks");

        routeGroup
            .Map<SearchTrucksEndpoint>()
            .Map<GetTruckDetailsEndpoint>()
            .Map<CreateTruckEndpoint>()
            .Map<UpdateTruckEndpoint>()
            .Map<DeleteTruckEndpoint>();
    }
    
    private static void MapDriverEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/drivers")
            .WithTags("Drivers");

        routeGroup
            .Map<SearchDriversEndpoint>();
    }
    
    private static void MapProducerEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/producers")
            .WithTags("Producers");

        routeGroup
            .Map<SearchProducersEndpoint>();
    }

    private static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/products")
            .WithTags("Products");

        routeGroup
            .Map<SearchProductsEndpoint>();
    }
    
    private static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder routeGroup = app.MapGroup("/customers")
            .WithTags("Customers");

        routeGroup
            .Map<SearchCustomersEndpoint>();
    }

    private static IEndpointRouteBuilder Map<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);

        return app;
    }
}