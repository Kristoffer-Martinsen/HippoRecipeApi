namespace HippoRecipeApi.Models;

public class Tag
{
    public int Id { get; set; }
    public string TagName { get; set; }
    public List<Recipe>? Recipes { get; set; } = [];
}