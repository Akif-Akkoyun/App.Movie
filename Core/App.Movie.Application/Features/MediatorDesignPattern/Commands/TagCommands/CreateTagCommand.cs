using MediatR;

namespace App.Movie.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class CreateTagCommand : IRequest
    {
        public string Title { get; set; }
    }
}
