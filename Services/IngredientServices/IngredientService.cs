using AutoMapper;
using HippoRecipeApi.Dtos;
using HippoRecipeApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Services;

public class IngredientService : IIngredientService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    
    public IngredientService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients()
    {
        var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
        var ingredients = await _context.Ingredients.ToListAsync();
        serviceResponse.Data = ingredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetIngredientDto>> GetIngredientById(int id)
    {
        var serviceResponse = new ServiceResponse<GetIngredientDto>();
        var ingredient = await _context.Ingredients.FindAsync(id);
        serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetIngredientDto>> AddIngredient(AddIngredientDto addIngredient)
    {
        var serviceResponse = new ServiceResponse<GetIngredientDto>();
        try
        {
            var ingredientToAdd = _mapper.Map<Ingredient>(addIngredient);
            _context.Ingredients.Add(ingredientToAdd);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredientToAdd);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetIngredientDto>> PutIngredient(int id, UpdateIngredientDto updateIngredient)
    {
        var serviceResponse = new ServiceResponse<GetIngredientDto>();
        try
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"No ingredient with {id} found";
                return serviceResponse;
            }

            _mapper.Map(updateIngredient, ingredient);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetIngredientDto>> PatchIngredient(int id, JsonPatchDocument<UpdateIngredientDto> patchDocument)
    {
        var serviceResponse = new ServiceResponse<GetIngredientDto>();
        try
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Ingredient with {id} does not exist";
                return serviceResponse;
            }

            dynamic ingredientToPatch = _mapper.Map<UpdateIngredientDto>(ingredient);
            patchDocument.ApplyTo(ingredientToPatch);
            _mapper.Map(ingredientToPatch, ingredient);
            serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Error: {ex.Message}";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetIngredientDto>> DeleteIngredient(int id)
    {
        var serviceResponse = new ServiceResponse<GetIngredientDto>();
        try
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);
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