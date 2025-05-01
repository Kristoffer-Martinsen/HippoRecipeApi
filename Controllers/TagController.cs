using HippoRecipeApi.Dtos.Tags;
using HippoRecipeApi.Models;
using HippoRecipeApi.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace HippoRecipeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetTagDto>>>> GetAllTags()
    {
        return Ok(await _tagService.GetAllTags());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetTagDto>>> DeleteTag(int id)
    {
        return Ok(await _tagService.DeleteTag(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetTagDto>>> AddTag(AddTagDto tag)
    {
        return Ok(await _tagService.AddTag(tag));
    }
}