using App.Movie.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using App.Movie.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using App.Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly DbContext _dbContext;

        public UpdateMovieCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void Handle(UpdateMovieCommand command)
        {
            var movie = await _dbContext.Set<MovieEntity>().FindAsync(command.Id);
            if (movie is null)
            {
                throw new Exception("Category not found");
            }
            movie.Status = command.Status;
            movie.Title = command.Title;
            movie.Description = command.Description;
            movie.ReleaseDate = command.ReleaseDate;
            movie.CreatedYear = command.CreatedYear;
            movie.CoverImageUrl = command.CoverImageUrl;
            movie.Duration = command.Duration;
            movie.Rating = command.Rating;
            await _dbContext.SaveChangesAsync();
        }
    }
}
