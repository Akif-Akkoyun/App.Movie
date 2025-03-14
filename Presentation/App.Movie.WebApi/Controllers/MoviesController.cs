using App.Movie.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using App
    .Movie.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using App.Movie.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }
        [HttpGet("/list")]
        public async Task<IActionResult> MovieList()
        {
            var result = await _getMovieQueryHandler.Handle();
            return Ok(result);
        }
        [HttpPost("/create")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Film Ekleme Başarılı");
        }
        [HttpDelete("/remove/{id}")]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Film Silme Başarılı");
        }
        [HttpPut("/update")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Film Güncelleme Başarılı");
        }
        [HttpGet("/movieListById/{id}")]
        public async Task<IActionResult> MovieListById(int id)
        {
            var result = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(result);
        }
    }
}
