using HippoRecipeApi.Dtos;
using HippoRecipeApi.Models;
using HippoRecipeApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HippoRecipeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<ActionResult<Ingredient>> GetAllIngredients()
    {
        return Ok(await _ingredientService.GetAllIngredients());
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> GetIngredientById(int id)
    {
        return Ok(await _ingredientService.GetIngredientById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> AddIngredient(AddIngredientDto addIngredient)
    {
        return Ok(await _ingredientService.AddIngredient(addIngredient));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> PutIngredient(int id,
        UpdateIngredientDto putIngredient)
    {
        return Ok(await _ingredientService.PutIngredient(id, putIngredient));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> PatchIngredient(int id,
        [FromBody] JsonPatchDocument<UpdateIngredientDto> patchDocument)
    {
        return Ok(await _ingredientService.PatchIngredient(id, patchDocument)); 
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> DeleteIngredient(int id)
    {
        return Ok(await _ingredientService.DeleteIngredient(id));
    }
}