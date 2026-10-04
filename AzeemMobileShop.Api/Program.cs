using AzeemMobileShop.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

// Register DbContext with Supabase PostgreSQL connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AzeemMobileShopDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/status", () =>
{
    return Results.Ok(new { status = "Azeem Mobile Shop API is running", timestamp = DateTime.UtcNow });
})
.WithName("GetStatus");

app.Run();
