using System.Text.Json;
using AutoMapper;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Services.RecipeServices;

public class RecipeService : IRecipeService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly ILogger<RecipeService> _logger;
    
    public RecipeService(IMapper mapper, DataContext context, ILogger<RecipeService> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<ServiceResponse<GetRecipeDto[]>> GetAllRecipes()
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto[]>();

        var recipes = await _context.Recipes.ToListAsync();
        serviceResponse.Data = _mapper.Map<GetRecipeDto[]>(recipes);
        _logger.LogInformation("ServiceResponse: {ServiceResponse}", 
            JsonSerializer.Serialize(serviceResponse));

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRecipeDto>> GetRecipeById(int id)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipe);
        _logger.LogInformation("ServiceResponse: {ServiceResponse}", 
            JsonSerializer.Serialize(recipe));      
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto addRecipe)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var newRecipe = new Recipe
            {
                Name = addRecipe.Name,
                Description = addRecipe.Description,
                Ingredients = addRecipe.Ingredients,
                Instructions = addRecipe.Instructions,
            };
            _context.Recipes.Add(newRecipe);
            serviceResponse.Data = _mapper.Map<GetRecipeDto>(newRecipe);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRecipeDto>> PutRecipe(int id, UpdateRecipeDto updateRecipe)
    {
        // TODO Need to be tested. sleepy time...
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"No recipe with {id} found";
                return serviceResponse;
            }

            _mapper.Map(updateRecipe, recipe);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipe);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
    }

    // public async Task<ServiceResponse<GetRecipeDto>> PatchRecipe(int id, JsonPatchDocument<UpdateRecipeDto> patchDocument)
    // {
    //     var serviceResponse = new ServiceResponse<GetRecipeDto>();
    //     try
    //     {
    //         var recipe = await _context.Recipes
    //             .Include(r => r.Ingredients)
    //             .FirstOrDefaultAsync(r => r.Id == id);
    //         if (recipe == null)
    //         {
    //             serviceResponse.Success = false;
    //             serviceResponse.Message = $"Recipe with {id} does not exist";
    //             return serviceResponse;
    //         }
    //         //TODO Patching item in ingredients applies null value to properties missing from request
    //         dynamic recipeToPatch = _mapper.Map<UpdateRecipeDto>(recipe);
    //         patchDocument.ApplyTo(recipeToPatch);
    //         _mapper.Map(recipeToPatch, recipe);
    //         serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipe);
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (Exception ex)
    //     {
    //         serviceResponse.Success = false;
    //         serviceResponse.Message = $"Error: {ex.Message}";
    //     }
    //
    //     return serviceResponse;
    // }

    public async Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int id)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var recipeToDelete = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipeToDelete);
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
    }
}