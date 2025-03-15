using App.Movie.Application.Features.MediatorDesignPattern.Commands.CastCommands;
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
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly DbContext _context;

        public RemoveCastCommandHandler(DbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Set<CastEntity>().Where(x => x.Id == request.Id).FirstOrDefault();
            _context.Set<CastEntity>().Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
