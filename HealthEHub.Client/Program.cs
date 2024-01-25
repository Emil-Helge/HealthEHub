using HealthEHub.Client;
using HealthEHub.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var environment = builder.HostEnvironment;

builder.Services.AddScoped(sp =>
{
    string apiBaseUrl = environment.IsDevelopment()
        ? "https://localhost:7024/"  // Local API for development
        : "https://healthehubappapi.azurewebsites.net/";  // Deployed API for production

    return new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
});

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<WorkoutPlanService>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddScoped<ThemeService>();

var host = builder.Build();

var authService = host.Services.GetRequiredService<AuthenticationService>();

await authService.Initialize();

await host.RunAsync();
