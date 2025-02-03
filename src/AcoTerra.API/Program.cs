using AcoTerra.API;
using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Common.Exceptions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Interceptors;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));

    #region Data

    string connectionString = builder.Configuration.GetConnectionString("Database")
        ?? throw new MissingConfigurationException("Database");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlite(connectionString)
            .AddInterceptors(new EnableForeignKeyInterceptor())
            .AddInterceptors(new AuditableEntityInterceptor())
            .UseSnakeCaseNamingConvention();

        options.EnableSensitiveDataLogging();
    });

    builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
    builder.Services.AddScoped<DatabaseInitializer>();

    #endregion
}

WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using (IServiceScope scope = app.Services.CreateScope())
    {
        var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

        await initializer.InitializeAsync();
        //await initializer.SeedAsync();
    }

    app.UseHttpsRedirection();

    app.MapEndpoints();

    app.Run();
}