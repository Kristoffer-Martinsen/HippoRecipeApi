using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<Tag> Tags => Set<Tag>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasMany(e => e.Ingredients);
    }
}