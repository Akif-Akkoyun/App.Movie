using App.Movie.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using App.Movie.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace App.Movie.WebApi
{
    public static class ServiceExtensions
    {
        public static void AddServicesRegistration(this IServiceCollection services)
        {
            #region Category
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            #endregion
            #region Movie
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            #endregion

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
            });
        }
    }
}
