using CraftLabs.Model;
using CraftLabs.Repositories;
using CraftLabs.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((builder) => {
    builder.AllowAnyOrigin();
});
app.UseHttpsRedirection();


app.MapGet("/customer", async ([FromServices] ICustomerService customerService) =>
{
    var result = await customerService.GetCustomersAsync();
    return Results.Ok(result);
})
.WithName("GetCustomer")
.WithOpenApi(); ;

app.MapPost("/customer", async ([FromBody] Customer newCustomer, ICustomerService customerService) => {
    await customerService.AddCustomerAsync(newCustomer);
    Results.Ok(newCustomer);
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
