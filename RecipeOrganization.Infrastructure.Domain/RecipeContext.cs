using Microsoft.EntityFrameworkCore;
using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Domain;

public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> option) : base(option) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Category> Categories { get; set; }
}
