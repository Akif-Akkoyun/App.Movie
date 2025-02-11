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
    public class RemoveCategoryCommandHandler
    {
        private readonly DbContext _dbContext;

        public RemoveCategoryCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void Handle(RemoveCategoryCommand command)
        {
            var category = await _dbContext.Set<CategoryEntity>().FindAsync(command.Id);
            if (category is null)
            {
                throw new Exception("Category not found");
            }
            _dbContext.Set<CategoryEntity>().Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
