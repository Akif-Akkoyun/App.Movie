using App.Movie.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
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
    public class GetCategoryByIdQueryHandler
    {
        private readonly DbContext _context;

        public GetCategoryByIdQueryHandler(DbContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query )
        {
            var values = await _context.Set<CategoryEntity>().Where(x => x.Id == query.Id).FirstOrDefaultAsync();
            if (values is null)
            {
                throw new InvalidOperationException("Movie not found");
            }
            return new GetCategoryByIdQueryResult
            {
                Id = values.Id,
                CategoryName = values.CategoryName
            };
        }
    }
}
