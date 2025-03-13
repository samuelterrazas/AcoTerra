using AcoTerra.Web.Services;
using Refit;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();

    builder.Services.AddRefitClient<ITruckService>()
        .ConfigureHttpClient((_, client) =>
        {
            client.BaseAddress = new Uri("https://localhost:7041/api/trucks");
            client.Timeout = TimeSpan.FromSeconds(30);
        });
    
    builder.Services.AddRefitClient<IAgentService>()
        .ConfigureHttpClient((_, client) =>
        {
            client.BaseAddress = new Uri("https://localhost:7041/api/agents");
            client.Timeout = TimeSpan.FromSeconds(30);
        });
}

WebApplication app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();


    app.Run();
}