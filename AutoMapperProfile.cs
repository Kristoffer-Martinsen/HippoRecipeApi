using AutoMapper;
using HippoRecipeApi.Dtos;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Dtos.Steps;
using HippoRecipeApi.Models;

namespace HippoRecipeApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Ingredient, GetIngredientDto>();
        CreateMap<AddIngredientDto, Ingredient>();
        CreateMap<UpdateIngredientDto, Ingredient>();
        CreateMap<Ingredient, UpdateIngredientDto>();

        CreateMap<Recipe, GetRecipeDto>();
        CreateMap<AddRecipeDto, Recipe>();
        CreateMap<UpdateRecipeDto, Recipe>();
        CreateMap<Recipe, UpdateRecipeDto>();
        
        CreateMap<Step, GetStepDto>();
        CreateMap<AddStepDto, Step>();
        CreateMap<UpdateStepDto, Step>();
        CreateMap<Step, UpdateStepDto>();
    }
}