using HealthEHub.Client;
using HealthEHub.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var environment = builder.HostEnvironment;

builder.Services.AddScoped(sp =>
{
    string apiBaseUrl = environment.IsDevelopment()
        ? "https://localhost:7024/"  // Local API for development
        : "https://healthhubappapi.azurewebsites.net/";  // Deployed API for production

    return new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
});

builder.Services.AddMudServices();
builder.Services.AddScoped<ThemeService>();


await builder.Build().RunAsync();

