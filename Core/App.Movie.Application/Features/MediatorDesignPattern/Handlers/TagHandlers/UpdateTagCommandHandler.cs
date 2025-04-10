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
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly DbContext _dbContext;
        public UpdateTagCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _dbContext.Set<TagEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (value != null)
            {
                value.Title = request.Title;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Tag not found");
            }
        }
    }
}
