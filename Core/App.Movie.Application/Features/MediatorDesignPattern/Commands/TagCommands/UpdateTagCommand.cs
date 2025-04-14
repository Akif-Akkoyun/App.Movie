using MediatR;

namespace App.Movie.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class UpdateTagCommand :IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
