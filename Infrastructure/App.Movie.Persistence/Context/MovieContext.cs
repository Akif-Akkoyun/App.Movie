using App.Movie.Domain.Entities;
using App.Movie.Persistence.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Movie.Persistence.Context
{
    internal class MovieContext : IdentityDbContext<AppUser>
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<CastEntity> Casts { get; set; }
    }
}
