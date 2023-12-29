using SharedModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7020")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddHttpClient("ExerciseClient", client =>
{
    client.BaseAddress = new Uri("https://exercisedb.p.rapidapi.com/");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "exercisedb.p.rapidapi.com");
    var apiKey = builder.Configuration["ExerciseDBAPIKey"];
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.MapGet("/exercises", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("ExerciseClient");
    var response = await client.GetAsync("exercises");
    return response.IsSuccessStatusCode
        ? Results.Ok(await response.Content.ReadFromJsonAsync<List<Exercise>>())
        : Results.Problem("API call failed.");
})
.WithName("GetExercises");

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

app.Run();
