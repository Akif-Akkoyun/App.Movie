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
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly DbContext _dbContext;

        public CreateCastCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(new CastEntity
            {
                Title = request.Title,
                Name = request.Name,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                OverView = request.OverView,
                Biograhpy = request.Biograhpy                
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
