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
        public async Task<IActionResult> GetCasts()
        {
            var value = await _mediator.Send(new GetCastQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCast(int id)
        {
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme İşlemi Başarılı.");
        }
        [HttpGet("GetCastById/{id}")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
    }
}
