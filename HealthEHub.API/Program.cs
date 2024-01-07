using HealthEHub.API.Services;
using SharedModels.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7020", "https://healthehubapp.azurewebsites.net")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddHttpClient("ExerciseClient", client =>
{
    client.BaseAddress = new Uri("https://exercisedb.p.rapidapi.com/");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "exercisedb.p.rapidapi.com");
    var apiKey = builder.Configuration["RapidAPIKey"];
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
});

builder.Services.AddHttpClient("YoutubeSearchClient", client =>
{
    client.BaseAddress = new Uri("https://youtube-search-and-download.p.rapidapi.com/");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "youtube-search-and-download.p.rapidapi.com");
    var apiKey = builder.Configuration["RapidAPIKey"];
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMockDataService, MockDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.MapGet("/exercise/{id}", async (string id, IHttpClientFactory clientFactory, IMockDataService mockDataService) =>
{
    if (app.Environment.IsDevelopment())
    {
        var mockExercises = mockDataService.GetExercises().FirstOrDefault(e => e.Id == id);
        return Results.Ok(mockExercises);
    }
    else
    {
        var client = clientFactory.CreateClient("ExerciseClient");
        var response = await client.GetAsync($"/exercises/exercise/{id}");
        return response.IsSuccessStatusCode
            ? Results.Ok(await response.Content.ReadFromJsonAsync<Exercise>())
            : Results.Problem("API call failed.");
    }
})
.WithName("GetExerciseById");

app.MapGet("/exercises", async (IHttpClientFactory clientFactory, IMockDataService mockDataService) =>
{
    if (app.Environment.IsDevelopment())
    {
        var mockExercises = mockDataService.GetExercises();
        return Results.Ok(mockExercises);
    }
    else
    {
        var client = clientFactory.CreateClient("ExerciseClient");
        var response = await client.GetAsync("exercises?limit=1300");
        return response.IsSuccessStatusCode
            ? Results.Ok(await response.Content.ReadFromJsonAsync<List<Exercise>>())
            : Results.Problem("API call failed.");
    }
})
.WithName("GetExercises");

app.MapGet("/bodyparts", async (IHttpClientFactory clientFactory, IMockDataService mockDataService) =>
{
    if (app.Environment.IsDevelopment())
    {
        var mockBodyParts = mockDataService.GetBodyParts();
        return Results.Ok(mockBodyParts);
    }
    else
    {
        var client = clientFactory.CreateClient("ExerciseClient");
        var response = await client.GetAsync("exercises/bodyPartList");
        return response.IsSuccessStatusCode
            ? Results.Ok(await response.Content.ReadFromJsonAsync<List<string>>())
            : Results.Problem("API call failed.");
    }
})
.WithName("GetBodyParts");

app.MapGet("/allequipment", async (IHttpClientFactory clientFactory, IMockDataService mockDataService) =>
{
    if (app.Environment.IsDevelopment())
    {
        var mockEquipment = mockDataService.GetAllEquipment();
        return Results.Ok(mockEquipment);
    }
    else
    {
        var client = clientFactory.CreateClient("ExerciseClient");
        var response = await client.GetAsync("exercises/equipmentList");
        return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<List<string>>())
        : Results.Problem("API call failed.");

    }
})
.WithName("GetAllEquipment");

app.MapGet("/targetmuscles", async (IHttpClientFactory clientFactory, IMockDataService mockDataService) =>
{
    if (app.Environment.IsDevelopment())
    {
        var mockTargetMuscles = mockDataService.GetTargetMuscles();
        return Results.Ok(mockTargetMuscles);
    }
    else
    {
        var client = clientFactory.CreateClient("ExerciseClient");
        var response = await client.GetAsync("exercises/targetList");
        return response.IsSuccessStatusCode
            ? Results.Ok(await response.Content.ReadFromJsonAsync<List<string>>())
            : Results.Problem("API call failed.");
    }
})
.WithName("GetTargetMuscles");

app.MapGet("/youtube/search", async (string query, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("YoutubeSearchClient");
    var response = await client.GetAsync($"https://youtube-search-and-download.p.rapidapi.com/search?query={query}&sort=v");

    return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<YoutubeSearchResult>())
        : Results.Problem("API call failed.");
})
.WithName("SearchYoutube");

app.Run();
