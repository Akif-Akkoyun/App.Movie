using App.Movie.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using App.Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler 
    {
        private readonly DbContext _dbContext;

        public CreateCategoryCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            _dbContext.Add(new CategoryEntity
            {
                CategoryName = command.CategoryName
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
