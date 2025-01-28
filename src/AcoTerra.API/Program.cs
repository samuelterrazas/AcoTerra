using AcoTerra.API;
using AcoTerra.API.Common.Exceptions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Interceptors;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    string connectionString = builder.Configuration.GetConnectionString("Database")
        ?? throw new MissingConfigurationException("Database");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlite(connectionString)
            .AddInterceptors(new EnableForeignKeyInterceptor())
            .AddInterceptors(new AuditableEntityInterceptor())
            .UseSnakeCaseNamingConvention();
    });
}

WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapEndpoints();

    app.Run();
}