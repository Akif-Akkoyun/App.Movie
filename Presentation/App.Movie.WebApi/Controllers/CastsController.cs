using App.Movie.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using App.Movie.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult GetCasts()
        {
            var value = _mediator.Send(new GetCastQuery());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCast(CreateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı.");
        }
        [HttpPut]
        public IActionResult UpdateCast(UpdateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı.");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCast(int id)
        {
            _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme İşlemi Başarılı.");
        }
        [HttpGet("GetCastById/{id}")]
        public IActionResult GetCastById(int id)
        {
            var value = _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
    }
}
