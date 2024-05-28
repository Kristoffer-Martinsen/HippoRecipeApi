using HippoRecipeApi.Dtos.Steps;
using HippoRecipeApi.Models;

namespace HippoRecipeApi.Dtos.Recipes;

public class AddRecipeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<AddIngredientDto> Ingredients { get; set; }
    public List<AddStepDto> Steps { get; set; }
}