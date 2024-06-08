using System.Text.Json.Serialization;

namespace HippoRecipeApi.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new();
    public List<Step> Steps { get; set; }
    public List<Tag>? Tags { get; set; } = [];
}