using App.Movie.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using App.Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly DbContext _dbContext;

        public UpdateCategoryCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _dbContext.Set<CategoryEntity>().FindAsync(command.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            category.CategoryName = command.CategoryName;
            await _dbContext.SaveChangesAsync();
        }
    }
}
