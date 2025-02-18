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
    public class RemoveMovieCommandHandler
    {
        private readonly DbContext _dbContext;

        public RemoveMovieCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(RemoveMovieCommand command)
        {
            var movie = await _dbContext.Set<MovieEntity>().FindAsync(command.Id);
            if (movie is null)
            {
                throw new InvalidOperationException("Movie not found");
            }
            _dbContext.Set<MovieEntity>().Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
