using HealthEHub.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

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

await builder.Build().RunAsync();

