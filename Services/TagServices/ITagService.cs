using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;

namespace HippoRecipeApi.Services.TagServices;

public interface ITagService
{
    Task<ServiceResponse<GetTagDto[]>> GetAllTags();
    Task<ServiceResponse<GetTagDto>> DeleteTag(int id);
    Task<ServiceResponse<GetTagDto>> AddTag(AddTagDto newTag);
}