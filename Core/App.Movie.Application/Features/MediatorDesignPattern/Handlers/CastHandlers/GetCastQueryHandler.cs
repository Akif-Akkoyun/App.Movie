using App.Movie.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using App.Movie.Application.Features.MediatorDesignPattern.Results.CastResults;
using App.Movie.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly DbContext _dbContext;

        public GetCastQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _dbContext.Set<CastEntity>().ToListAsync();
            return values.Select(x => new GetCastQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Name = x.Name,
                Surname = x.Surname,
                ImageUrl = x.ImageUrl,
                OverView = x.OverView,
                Biograhpy = x.Biograhpy
            }).ToList();
        }
    }
}
