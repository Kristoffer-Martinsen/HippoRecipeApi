using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;

namespace HippoRecipeApi.Mappers;

public static class RecipeMapper
{
    public static GetRecipeDto MapToGetDto(Recipe recipe)
    {
        return new GetRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients,
            Instructions = recipe.Instructions,
            Tags = recipe.Tags?.Select(tag => new GetTagDto { TagName = tag.TagName }).ToList()
        };
    }

    public static AddRecipeDto MapToAddDto(Recipe recipe)
    {
        return new AddRecipeDto
        {
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients,
            Instructions = recipe.Instructions,
            Tags = recipe.Tags?.Select(tag => new AddTagDto() { TagName = tag.TagName }).ToList()
        };
    }
}