
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Mappers;
using HippoRecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Services.TagServices;

public class TagService : ITagService
{
    private readonly DataContext _context;

    public TagService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<GetTagDto[]>> GetAllTags()
    {
        var serviceResponse = new ServiceResponse<GetTagDto[]>();
        var tags = await _context.Tags.ToListAsync();
        serviceResponse.Data = tags.Select(TagMapper.GetTagDto).ToArray();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetTagDto>> DeleteTag(int id)
    {
        var serviceResponse = new ServiceResponse<GetTagDto>();
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            serviceResponse.Data = TagMapper.GetTagDto(tag);
        }
        else
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Tag not found";
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetTagDto>> AddTag(AddTagDto newTag)
    {
        var serviceResponse = new ServiceResponse<GetTagDto>();
        try
        {
            var tagToAdd = new Tag
            {
                TagName = newTag.TagName,
            };
            
            _context.Tags.Add(tagToAdd);
            await _context.SaveChangesAsync();
            serviceResponse.Data = TagMapper.GetTagDto(tagToAdd);
            
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}