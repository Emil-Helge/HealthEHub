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
builder.Services.AddHttpClient();
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

app.MapGet("/exercisedata", async (IHttpClientFactory clientFactory, IConfiguration config) =>
{
    var client = clientFactory.CreateClient();
    var apiKey = config["ExerciseDBAPIKey"];
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "exercisedb.p.rapidapi.com");
    var response = await client.GetAsync("https://exercisedb.p.rapidapi.com/exercises");
    return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<object>() : Results.Problem("API call failed.");
})
.WithName("GetExerciseData")
.WithOpenApi();

app.Run();
