using App.Movie.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using App.Movie.Application.Features.CQRSDesignPattern.Results.MovieReulsts;
using App.Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly DbContext _dbContext;

        public GetMovieByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var values = await _dbContext.Set<MovieEntity>().Where(x => x.Id == query.Id).FirstOrDefaultAsync();
            if (values is null)
            {
                throw new InvalidOperationException("Movie not found");
            }
            return new GetMovieByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                ReleaseDate = values.ReleaseDate,
                Rating = values.Rating,
                CoverImageUrl = values.CoverImageUrl,
                CreatedYear = values.CreatedYear,
                Duration = values.Duration,
                Status = values.Status
            };
        }
    }
}
