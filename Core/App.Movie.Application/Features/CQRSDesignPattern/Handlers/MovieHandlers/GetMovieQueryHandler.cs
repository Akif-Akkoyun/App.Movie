using App.Movie.Application.Features.CQRSDesignPattern.Results.MovieReulsts;
using App.Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly DbContext _dbContext;

        public GetMovieQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = await _dbContext.Set<MovieEntity>().ToListAsync();
            return values.Select(x => new GetMovieQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status
            }).ToList();
        }
    }
}
