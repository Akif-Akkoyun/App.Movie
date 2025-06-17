using App.Movie.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using App.Movie.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler(DbContext _db,SignInManager<AppUser> _userManager)
    {
        public async Task Handle(CreateUserRegisterCommand command)
        {
            var user = new AppUser
            {
                UserName = command.UserName,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            var result = await _userManager.UserManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
