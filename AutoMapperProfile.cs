using AutoMapper;
using HippoRecipeApi.Dtos.Recipes;
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;

namespace HippoRecipeApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Recipe, GetRecipeDto>();
        CreateMap<AddRecipeDto, Recipe>();
        CreateMap<UpdateRecipeDto, Recipe>();
        CreateMap<Recipe, UpdateRecipeDto>();

        // CreateMap<Tag, TagDto>();
        
    }
}