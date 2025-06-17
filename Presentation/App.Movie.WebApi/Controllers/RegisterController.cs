using App.Movie.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using App.Movie.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _createUserRegisterCommandHandler;

        public RegisterController(CreateUserRegisterCommandHandler createUserRegisterCommandHandler)
        {
            _createUserRegisterCommandHandler = createUserRegisterCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRegisterCommand command)
        {
            if (command is null)
            {
                return BadRequest("Invalid user registration data.");
            }
            try
            {
                await _createUserRegisterCommandHandler.Handle(command);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error registering user: {ex.Message}");
            }
        }
    }
}
