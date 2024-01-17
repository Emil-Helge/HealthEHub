using HealthEHub.API.Data;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using HealthEHub.API.Services;

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

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HealthEHubContext>(options =>
    options.UseSqlServer(connectionString));

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
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.MapGet("/exercise/{id}", async (string id, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    var response = await client.GetAsync($"/exercises/exercise/{id}");
    return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<Exercise>())
        : Results.Problem("API call failed.");
})
.WithName("GetExerciseById");

app.MapGet("/exercises", async (int limit, int offset, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    string requestUri = $"exercises?limit={limit}&offset={offset}";

    var response = await client.GetAsync(requestUri);
    if (response.IsSuccessStatusCode)
    {
        var exercises = await response.Content.ReadFromJsonAsync<List<Exercise>>();
        return Results.Ok(exercises);
    }
    else
    {
        return Results.Problem("API call to external service failed.");
    }
}).WithName("GetExercises");

app.MapGet("/exercises/bodyPart/{bodyPart}", async (string bodyPart, int limit, int offset, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    string requestUri = $"exercises/bodyPart/{bodyPart}?limit={limit}&offset={offset}";

    var response = await client.GetAsync(requestUri);
    if (response.IsSuccessStatusCode)
    {
        var exercises = await response.Content.ReadFromJsonAsync<List<Exercise>>();
        return Results.Ok(exercises);
    }
    else
    {
        return Results.Problem("API call to external service failed.");
    }
}).WithName("GetExercisesByBodyPart");

app.MapGet("/exercises/equipment/{type}", async (string type, int limit, int offset, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    string requestUri = $"exercises/equipment/{type}?limit={limit}&offset={offset}";

    var response = await client.GetAsync(requestUri);
    if (response.IsSuccessStatusCode)
    {
        var exercises = await response.Content.ReadFromJsonAsync<List<Exercise>>();
        return Results.Ok(exercises);
    }
    else
    {
        return Results.Problem("API call to external service failed.");
    }
}).WithName("GetExercisesByEquipment");

app.MapGet("/exercises/target/{target}", async (string target, int limit, int offset, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    string requestUri = $"exercises/target/{target}?limit={limit}&offset={offset}";

    var response = await client.GetAsync(requestUri);
    if (response.IsSuccessStatusCode)
    {
        var exercises = await response.Content.ReadFromJsonAsync<List<Exercise>>();
        return Results.Ok(exercises);
    }
    else
    {
        return Results.Problem("API call to external service failed.");
    }
}).WithName("GetExercisesByTarget");

app.MapGet("/exercises/name/{name}", async (string name, int limit, int offset, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    string requestUri = $"exercises/name/{name}?limit={limit}&offset={offset}";

    var response = await client.GetAsync(requestUri);
    if (response.IsSuccessStatusCode)
    {
        var exercises = await response.Content.ReadFromJsonAsync<List<Exercise>>();
        return Results.Ok(exercises);
    }
    else
    {
        return Results.Problem("API call to external service failed.");
    }
}).WithName("GetExercisesByName");

app.MapGet("/bodyparts", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    var response = await client.GetAsync("exercises/bodyPartList");
    return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<List<string>>())
        : Results.Problem("API call failed.");
})
.WithName("GetBodyParts");

app.MapGet("/allequipment", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    var response = await client.GetAsync("exercises/equipmentList");
    return response.IsSuccessStatusCode
    ? Results.Ok(await response.Content.ReadFromJsonAsync<List<string>>())
    : Results.Problem("API call failed.");
})
.WithName("GetAllEquipment");

app.MapGet("/targetmuscles", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    var response = await client.GetAsync("exercises/targetList");
    return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<List<string>>())
        : Results.Problem("API call failed.");
})
.WithName("GetTargetMuscles");

app.MapGet("/youtube/search", async (string query, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("YoutubeSearchClient");
    string queryAppendExercise = $"{query} exercise";
    var response = await client.GetAsync($"https://youtube-search-and-download.p.rapidapi.com/search?query={queryAppendExercise}&sort=r");

    return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<YoutubeSearchResult>())
        : Results.Problem("API call failed.");
})
.WithName("SearchYoutube");

app.MapPost("/register", async (HttpContext context) =>
{
    var userService = context.RequestServices.GetRequiredService<UserService>();
    var user = await context.Request.ReadFromJsonAsync<User>();
    if (user == null)
    {
        return Results.BadRequest("Invalid user data.");
    }
    var registeredUser = await userService.Register(user.Username, user.Email, user.PasswordHash);
    return Results.Created($"/users/{registeredUser.UserId}", registeredUser);
}).Produces<User>(StatusCodes.Status201Created);

app.MapPost("/login", async (HttpContext context) =>
{
    var userService = context.RequestServices.GetRequiredService<UserService>();
    var user = await context.Request.ReadFromJsonAsync<User>();
    if (user == null)
    {
        return Results.BadRequest("Invalid user data.");
    }
    var loggedInUser = await userService.Login(user.Username, user.PasswordHash);
    if (loggedInUser == null)
    {
        return Results.Unauthorized();
    }

    return Results.Ok(loggedInUser);
}).Produces<User>(StatusCodes.Status200OK);

app.Run();
