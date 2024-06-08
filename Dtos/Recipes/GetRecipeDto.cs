using HippoRecipeApi.Dtos.Steps;
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;

namespace HippoRecipeApi.Dtos.Recipes;

public class GetRecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GetIngredientDto> Ingredients { get; set; }
    public List<GetStepDto> Steps { get; set; }
    public List<TagDto>? Tags { get; set; }
}   