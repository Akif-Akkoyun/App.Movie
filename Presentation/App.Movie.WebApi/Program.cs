using App.Movie.Persistence;
using App.Movie.WebApi;

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
    app.MapGet("/", () => Results.Redirect("/swagger"))
         .ExcludeFromDescription();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();