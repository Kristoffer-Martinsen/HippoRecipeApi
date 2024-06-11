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
    public async Task<ActionResult<ServiceResponse<List<TagDto>>>> GetAllTags()
    {
        return Ok(await _tagService.GetAllTags());
    }

}