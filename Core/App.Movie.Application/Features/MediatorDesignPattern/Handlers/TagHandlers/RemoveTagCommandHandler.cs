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
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly DbContext _context;

        public RemoveTagCommandHandler(DbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var value = _context.Set<TagEntity>().Where(x => x.Id == request.Id).FirstOrDefault();
            if (value != null)
            {
                _context.Set<TagEntity>().Remove(value);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Tag not found");
            }
        }
    }
}
