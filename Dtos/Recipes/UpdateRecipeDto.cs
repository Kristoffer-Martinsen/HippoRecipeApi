using HippoRecipeApi.Models;

namespace HippoRecipeApi.Dtos.Recipes;

public class UpdateRecipeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UpdateIngredientDto> Ingredients { get; set; }
    public List<Step> Steps { get; set; }
}