using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;

namespace HippoRecipeApi.Mappers;

public static class TagMapper
{
    public static GetTagDto GetTagDto(Tag tag)
    {
        return new GetTagDto
        {
            Id = tag.Id,
            TagName = tag.TagName
        };
    }
}