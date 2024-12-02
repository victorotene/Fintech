using Fintech.Domain.Entities;
using Fintech.Infrastructure.Persistance;
using Fintech.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Configuration.GetConnectionString("FintechDB");
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<FintechDbContext>();
builder.Services.AddDbContext<FintechDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FintechDB")));

var app = builder.Build();

//var scope = app.Services.CreateScope();
//var seeder = scope.ServiceProvider.GetRequiredService<IFintechSeeders>();

//await seeder.Seed();
app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/health");

app.MapIdentityApi<User>();
/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();
    
    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
   {
       public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
   }
*/
app.Run();

