using HippoRecipeApi.Models;

namespace HippoRecipeApi.Dtos.Recipes;

public class GetRecipeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GetIngredientDto> Ingredients { get; set; }
}