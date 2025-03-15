using App.Movie.Persistence;
using App.Movie.WebApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesRegistration();

builder.Services.AddControllers();

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection String Not Found !!");

builder.Services.AddDataLayer(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
