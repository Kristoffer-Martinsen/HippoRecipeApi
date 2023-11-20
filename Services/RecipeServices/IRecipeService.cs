using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace HippoRecipeApi.Services.RecipeServices;

public interface IRecipeService
{
    Task<ServiceResponse<List<GetRecipeDto>>> GetAllRecipes();
    Task<ServiceResponse<GetRecipeDto>> GetRecipeById(int id);
    Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto addRecipe);
    Task<ServiceResponse<GetRecipeDto>> PutRecipe(int id, UpdateRecipeDto updateRecipe);
    Task<ServiceResponse<GetRecipeDto>> PatchRecipe(int id,
        JsonPatchDocument<UpdateRecipeDto> patchDocument);
    Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int id);
}