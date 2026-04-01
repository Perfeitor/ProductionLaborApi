using Microsoft.EntityFrameworkCore;
using ProductionLaborApi.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ApplicationDbContext>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseNpgsql(configuration.GetConnectionString("DefaultConnection") ?? "")
        .Options;
    return new ApplicationDbContext(options);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();