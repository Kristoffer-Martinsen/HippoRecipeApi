using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
}