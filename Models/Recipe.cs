using System.Text.Json.Serialization;

namespace HippoRecipeApi.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new();
    public string ImageURL { get; set; }

    public List<Step> Steps { get; set; }
}