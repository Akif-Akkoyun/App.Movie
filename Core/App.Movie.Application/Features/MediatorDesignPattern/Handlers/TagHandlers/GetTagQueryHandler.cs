using App.Movie.Application.Features.MediatorDesignPattern.Queries.TagQyeries;
using App.Movie.Application.Features.MediatorDesignPattern.Results.TagResults;
using App.Movie.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagQueryHandler :IRequestHandler<GetTagQuery,List<GetTagQueryResult>>
    {
        private readonly DbContext _dbContext;

        public GetTagQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _dbContext.Set<TagEntity>().ToListAsync();
            return values.Select(x => new GetTagQueryResult
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }
    }
}
