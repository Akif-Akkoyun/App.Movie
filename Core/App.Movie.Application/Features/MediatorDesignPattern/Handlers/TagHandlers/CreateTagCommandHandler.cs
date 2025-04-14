using App.Movie.Application.Features.MediatorDesignPattern.Commands.TagCommands;
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
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly DbContext _dbContext;

        public CreateTagCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(new TagEntity
            {
                Title = request.Title
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
