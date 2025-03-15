using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class CreateCastCommand : IRequest
    {
        public string Title { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string? OverView { get; set; }
        public string? Biograhpy { get; set; }
    }
}
