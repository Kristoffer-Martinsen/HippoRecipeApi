using System.Text.Json.Serialization;

namespace HippoRecipeApi.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    [JsonIgnore] public List<Recipe> Recipes { get; set; } = new();
}