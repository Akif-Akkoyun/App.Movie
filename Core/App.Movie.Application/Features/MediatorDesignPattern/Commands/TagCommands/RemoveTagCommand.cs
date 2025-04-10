using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class RemoveTagCommand :IRequest
    {
        public int Id { get; set; }

        public RemoveTagCommand(int id)
        {
            Id = id;
        }
    }
}
