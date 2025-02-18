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
    public class CreateMovieCommandHandler
    {
        private readonly DbContext _dbContext;

        public CreateMovieCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(CreateMovieCommand command)
        {
            _dbContext.Add(new MovieEntity
            {
                Title = command.Title,
                Description = command.Description,
                ReleaseDate = command.ReleaseDate,
                Rating = command.Rating,
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Duration = command.Duration,
                Status = command.Status
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
