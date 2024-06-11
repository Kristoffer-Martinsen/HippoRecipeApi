using AutoMapper;
using HippoRecipeApi.Dtos;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Dtos.Steps;
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Services.RecipeServices;

public class RecipeService : IRecipeService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    
    public RecipeService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetRecipeDto>>> GetAllRecipes()
    {
        var serviceResponse = new ServiceResponse<List<GetRecipeDto>>();

        var recipes = await _context.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .Include(r => r.Tags)
            .ToListAsync();
        
        serviceResponse.Data = recipes
            .Select(r => new GetRecipeDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Ingredients = 
                    r.Ingredients.Select(i => new GetIngredientDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Unit = i.Unit,
                    Amount = i.Amount
                }).ToList(),
                Steps = r.Steps.Select(s => new GetStepDto
                {
                    Id = s.Id,
                    Instruction = s.Instruction
                }).ToList(),
                Tags = r.Tags.Any() ? 
                    r.Tags.Select(t => new TagDto
                        {
                            Id = t.Id,
                            TagName = t.TagName
                        }).ToList()
                    : null
            }).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRecipeDto>> GetRecipeById(int id)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();

        var recipe = await _context.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
            .Include(r => r.Tags)
            .FirstOrDefaultAsync(r => r.Id == id);
        serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipe);
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
            };

            var ingredients = addRecipe.Ingredients.Select(i
                => new Ingredient
                {
                    Name = i.Name, Unit = i.Unit, Recipe = newRecipe, Amount = i.Amount
                }).ToList();
            var steps = addRecipe.Steps.Select(
                s => new Step { Instruction = s.Instruction, Recipe = newRecipe}).ToList();
            var tags = addRecipe.Tags.Select(
                t => new Tag { Id = t.Id, TagName = t.TagName }).ToList();
            
            newRecipe.Ingredients = ingredients;
            newRecipe.Steps = steps;
            newRecipe.Tags = tags;
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
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .Include(r => r.Tags)
                .FirstOrDefaultAsync(r => r.Id == id);
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

    public async Task<ServiceResponse<GetRecipeDto>> PatchRecipe(int id, JsonPatchDocument<UpdateRecipeDto> patchDocument)
    {
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Recipe with {id} does not exist";
                return serviceResponse;
            }
            //TODO Patching item in ingredients applies null value to properties missing from request
            dynamic recipeToPatch = _mapper.Map<UpdateRecipeDto>(recipe);
            patchDocument.ApplyTo(recipeToPatch);
            _mapper.Map(recipeToPatch, recipe);
            serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipe);
            await _context.SaveChangesAsync();
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
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);
            
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