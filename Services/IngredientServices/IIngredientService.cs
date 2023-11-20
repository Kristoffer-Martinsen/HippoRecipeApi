using HippoRecipeApi.Dtos;
using HippoRecipeApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace HippoRecipeApi.Services;

public interface IIngredientService
{
    Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients();
    Task<ServiceResponse<GetIngredientDto>> GetIngredientById(int id);
    Task<ServiceResponse<GetIngredientDto>> AddIngredient(AddIngredientDto addIngredient);
    Task<ServiceResponse<GetIngredientDto>> PutIngredient(int id, UpdateIngredientDto updateIngredient);
    Task<ServiceResponse<GetIngredientDto>> PatchIngredient(int id,
        JsonPatchDocument<UpdateIngredientDto> patchDocument);
    Task<ServiceResponse<GetIngredientDto>> DeleteIngredient(int id);


}