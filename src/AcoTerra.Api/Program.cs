using AcoTerra.Api.Endpoints;
using AcoTerra.Core;
using AcoTerra.Infrastructure;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddOpenApi();
    
    builder.Services.AddCore();
    builder.Services.AddInfrastructure(builder.Configuration);
}

WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Title = "AcoTerra API";
            options.Layout = ScalarLayout.Classic;
            options.Theme = ScalarTheme.Moon;
            options.HideClientButton = true;
        });
    }

    app.UseHttpsRedirection();
    
    app.MapTruckEndpoints();
    app.MapTrailerEndpoints();
    app.MapAgentEndpoints();

    app.Run();
}