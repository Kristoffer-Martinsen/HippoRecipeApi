using AutoMapper;
using HippoRecipeApi.Dtos;
using HippoRecipeApi.Dtos.Recipes;
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
            .ToListAsync();
        
        serviceResponse.Data = recipes
            .Select(r => new GetRecipeDto
            {
                Name = r.Name,
                Description = r.Description,
                Ingredients = 
                    r.Ingredients.Select(i => new GetIngredientDto
                {
                    Name = i.Name,
                    Unit = i.Unit
                }).ToList()
            }).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRecipeDto>> GetRecipeById(int id)
    {
        throw new NotImplementedException();
        /*
        var serviceResponse = new ServiceResponse<GetRecipeDto>();

        var recipe = _context.Recipes
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Id == id);
        serviceResponse.Data = _mapper.Map<GetRecipeDto>(recipe);
        return serviceResponse;
        */
    }

    public async Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto addRecipe)
    {
        throw new NotImplementedException();
        /*
        var serviceResponse = new ServiceResponse<GetRecipeDto>();
        try
        {
            var newRecipe = new Recipe
            {
                Name = addRecipe.Name,
                Description = addRecipe.Description
            };

            var ingredients = addRecipe.Ingredients.Select(i
                => new Ingredient { Name = i.Name, Unit = i.Unit, Recipes = new List<Recipe>{newRecipe}}).ToList();
            newRecipe.Ingredients = ingredients;
            _context.Recipes.Add(newRecipe);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
        */
    }

    public async Task<ServiceResponse<GetRecipeDto>> PutRecipe(int id, UpdateRecipeDto updateRecipe)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GetRecipeDto>> PatchRecipe(int id, JsonPatchDocument<UpdateRecipeDto> patchDocument)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int id)
    {
        throw new NotImplementedException();
    }
}