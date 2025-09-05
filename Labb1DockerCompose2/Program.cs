using Microsoft.EntityFrameworkCore;
using Labb1DockerCompose2.Data;
using Labb1DockerCompose2.Models;

namespace Labb1DockerCompose2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Koppla till Databasen
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Minimal API endpoints
            // GET
            app.MapGet("/Products", async (ProductContext db) =>
            {
                var products = await db.Products.ToListAsync();
                return Results.Ok(products);
            });

            //POST
            app.MapPost("/Products", async (ProductContext db, Product product) =>
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return Results.Created($"/products/{product.Id}", product);
            });

            //DELETE
            app.MapDelete("/products/{id}", async (ProductContext db, int id) =>
            {
                var product = await db.Products.FindAsync(id);
                if (product == null)
                {
                    return Results.NotFound();
                }
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}
