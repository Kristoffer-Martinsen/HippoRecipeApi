namespace HippoRecipeApi.Models;

public class Step
{
    public int Id { get; set; }
    public string Instruction { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}