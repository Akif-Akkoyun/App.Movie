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
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly DbContext _dbContext;

        public GetCastByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _dbContext.Set<CastEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);
            return new GetCastByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Name = values.Name,
                Surname = values.Surname,
                ImageUrl = values.ImageUrl,
                OverView = values.OverView,
                Biograhpy = values.Biograhpy
            };
        }
    }
}
