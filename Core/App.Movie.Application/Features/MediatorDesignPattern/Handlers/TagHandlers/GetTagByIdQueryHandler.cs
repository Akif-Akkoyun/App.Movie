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
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagQueryByIdQueryResult>
    {
        private readonly DbContext _dbContext;

        public GetTagByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTagQueryByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _dbContext.Set<TagEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);
            if(value != null)
            {
                return new GetTagQueryByIdQueryResult
                {
                    Id = value.Id,
                    Title = value.Title
                };
            }
            else
            {
                 throw new InvalidOperationException("Tag not found");
            }
        }
    }
}
