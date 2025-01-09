using HippoRecipeApi.Dtos.Tags;

namespace HippoRecipeApi.Dtos.Recipes;

public class UpdateRecipeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    // public List<TagDto>? Tags { get; set; }
}