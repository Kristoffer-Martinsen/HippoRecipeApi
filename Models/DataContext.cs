using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Recipe> Recipes => Set<Recipe>();
    // public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = 1, 
                Name = "Creamy Garlic Pasta", 
                Description = "Creamy Garlic Pasta perfect for meal prep", 
                Ingredients = "5 Fedd hvitløk\n    4Tomater\n    2Paprika\n    2tsLøkpulver\n    1ts Oregano\n    1ts Basilikum\n    4ts Paprika krydder\n    180ml Kyllingbuljong\n    240grams Kesam\n    800grams Kjøttdeig\n    500grams Pasta\n    50grams Parmesan\n",
                Instructions = "Kutt tomater og paprika i biter. Rasp hvitløk.\n    Ha olje i ei panne og stek tomater og paprika. Tilsett litt salt og pepper. La dette steke i 6 minutter.\n    Kok opp vann til pasta. Tilsett hvitløk til tomatene og paprikaen å la det steke i 4 minutter.\n    Tilsett halvparten av kryddere og stek i 3 minutter\n    Tilsett kyllingbuljong og kok i 10 minutter\n    La sausen kjøle seg ned før den blendes sammen med kesam og blend til den er kremet\n    Kok pasta 1 minutt mindre enn pakken krever\n    Stek kjøttdeig til den er nesten helt gjennomstekt. Tilsett resten av kryddere\n    Tilsett sausen fra blenderen til kjøttdeigen og la det steke i 2 minutter\n    Når pastaen er ferdig hell den over til kjøttdeigen og sausen. Bland og la den koke i 1-2 minutter\n"
            }
        );
    }

}