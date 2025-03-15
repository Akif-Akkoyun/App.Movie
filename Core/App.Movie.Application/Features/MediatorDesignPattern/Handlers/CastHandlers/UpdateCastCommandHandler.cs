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
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly DbContext _dbContext;

        public UpdateCastCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _dbContext.Set<CastEntity>().Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            values.Title = request.Title;
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.ImageUrl = request.ImageUrl;
            values.OverView = request.OverView;
            values.Biograhpy = request.Biograhpy;

            await _dbContext.SaveChangesAsync();

        }
    }
}
