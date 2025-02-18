using App.Movie.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using App.Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly DbContext _dbContext;
        public GetCategoryQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _dbContext.Set<CategoryEntity>().ToListAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryName = x.CategoryName,
                Id = x.Id
            }).ToList();
        }
    }
}
