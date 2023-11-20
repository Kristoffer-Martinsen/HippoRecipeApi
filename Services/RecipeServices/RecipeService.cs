using AutoMapper;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Models;
using Microsoft.AspNetCore.JsonPatch;

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
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GetRecipeDto>> GetRecipeById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GetRecipeDto>> AddRecipe(AddRecipeDto addRecipe)
    {
        throw new NotImplementedException();
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