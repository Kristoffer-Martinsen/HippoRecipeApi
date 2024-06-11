using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;

namespace HippoRecipeApi.Services.TagServices;

public interface ITagService
{
    Task<ServiceResponse<List<TagDto>>> GetAllTags();
}