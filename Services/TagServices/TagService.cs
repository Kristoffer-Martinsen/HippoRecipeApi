using AutoMapper;
using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HippoRecipeApi.Services.TagServices;

public class TagService : ITagService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public TagService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<TagDto>>> GetAllTags()
    {
        var serviceResponse = new ServiceResponse<List<TagDto>>();
        var tags = await _context.Tags.ToListAsync();
        serviceResponse.Data = tags.Select(t => _mapper.Map<TagDto>(t)).ToList();
        return serviceResponse;
    }
}