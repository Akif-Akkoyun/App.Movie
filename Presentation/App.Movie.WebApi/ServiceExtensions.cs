using App.Movie.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using App.Movie.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

namespace App.Movie.WebApi
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
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
        }
    }
}
