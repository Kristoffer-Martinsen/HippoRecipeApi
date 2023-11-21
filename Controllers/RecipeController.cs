using HippoRecipeApi.Dtos;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Models;
using HippoRecipeApi.Services.RecipeServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HippoRecipeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    
    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> GetAllRecipes()
    {
        return Ok(await _recipeService.GetAllRecipes());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> GetRecipeById(int id)
    {
        return Ok(await _recipeService.GetRecipeById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> AddRecipe(AddRecipeDto addRecipe)
    {
        return Ok(await _recipeService.AddRecipe(addRecipe));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> PutRecipe(int id, UpdateRecipeDto updateRecipe)
    {
        return Ok(await _recipeService.PutRecipe(id, updateRecipe));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> PatchRecipe(int id,
        [FromBody] JsonPatchDocument<UpdateRecipeDto> patchDocument)
    {
        return Ok(await _recipeService.PatchRecipe(id, patchDocument));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> DeleteRecipe(int id)
    {
        return Ok(await _recipeService.DeleteRecipe(id));
    }
}