using HippoRecipeApi.Dtos.Steps;
using HippoRecipeApi.Dtos.Tags;

namespace HippoRecipeApi.Dtos.Recipes;

public class UpdateRecipeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UpdateIngredientDto> Ingredients { get; set; }
    public List<UpdateStepDto> Steps { get; set; }
    public List<TagDto>? Tags { get; set; }
}