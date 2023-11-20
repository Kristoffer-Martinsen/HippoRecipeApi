using AutoMapper;
using HippoRecipeApi.Dtos;
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
    }
}