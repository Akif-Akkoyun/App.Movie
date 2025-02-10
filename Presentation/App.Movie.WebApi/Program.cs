using App.Movie.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection String Not Found !!");

builder.Services.AddDataLayer(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
