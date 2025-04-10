using System.Text.Json;
using AutoMapper;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Mappers;
using HippoRecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Services.RecipeServices;

public class RecipeService : IRecipeService
{
    private readonly DataContext _context;
    private readonly ILogger<RecipeService> _logger;
    
    public RecipeService(DataContext context, ILogger<RecipeService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ServiceResponse<GetRecipeDto[]>> GetAllRecipes()
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto[]>();

        var recipes = await _context.Recipes
            .Include(r => r.Tags)
            .ToListAsync();
        serviceResponse.Data = recipes.Select(RecipeMapper.MapToGetDto).ToArray();

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRecipeDto>> GetRecipeById(int id)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        var recipe = await _context.Recipes
            .Include(r => r.Tags)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (recipe != null)
        {
            serviceResponse.Data = RecipeMapper.MapToGetDto(recipe);
        }
        else
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Recipe not found";
        }
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
                Tags = new List<Tag>()
            };

            if (addRecipe.Tags != null)
            {
                foreach (var tagDto in addRecipe.Tags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagDto.TagName);
                    if (tag == null)
                    {
                        tag = new Tag { TagName = tagDto.TagName };
                        _context.Tags.Add(tag);
                    }
                    newRecipe.Tags.Add(tag);
                }
            }
            _context.Recipes.Add(newRecipe);
            await _context.SaveChangesAsync();
            serviceResponse.Data = RecipeMapper.MapToGetDto(newRecipe);
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
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var recipe = await _context.Recipes
                .Include(r => r.Tags)
                .FirstOrDefaultAsync(r => r.Id == id);
            
            if (recipe == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"No recipe with {id} found";
                return serviceResponse;
            }
    
            recipe.Name = updateRecipe.Name;
            recipe.Description = updateRecipe.Description;
            recipe.Ingredients = updateRecipe.Ingredients;
            recipe.Instructions = updateRecipe.Instructions;

            if (updateRecipe.Tags != null)
            {
                recipe.Tags.Clear();

                foreach (var tagDto in updateRecipe.Tags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagDto.TagName);
                    if (tag == null)
                    {
                        tag = new Tag { TagName = tagDto.TagName };
                        _context.Tags.Add(tag);
                    }
                    recipe.Tags.Add(tag);
                }
            }
            await _context.SaveChangesAsync();
            serviceResponse.Data = RecipeMapper.MapToGetDto(recipe);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }
    
        return serviceResponse;
    }
    
    public async Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int id)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var recipeToDelete = await _context.Recipes
                .Include(r => r.Tags)
                .FirstOrDefaultAsync(r => r.Id == id);
            
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                serviceResponse.Data = RecipeMapper.MapToGetDto(recipeToDelete);
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