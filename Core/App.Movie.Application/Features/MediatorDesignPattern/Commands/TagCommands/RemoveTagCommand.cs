using MediatR;

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
