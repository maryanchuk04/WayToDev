using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.Mapping;
using WayToDev.Client.ViewModels;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

/// <summary>
/// Tag API controller
/// </summary>
[ApiController]
[Route("api/tags")]
public class TagsController : ControllerBase
{
    private ITagService _tagService;
    
    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    /// <summary>
    /// Get All tags from database
    /// </summary>
    /// <responce code = "200">Return all tags</responce>
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _tagService.GetAllTags());

    /// <summary>
    /// Insert new tag
    /// </summary>
    /// <param name="tagViewModel">tag view model</param>
    /// <responce code = "200">Return new tag</responce>
    /// <responce code = "400">Return error</responce>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TagViewModel tagViewModel)
    {
        try
        {
           return Ok(await _tagService.InsertNewTag(tagViewModel.TagName, tagViewModel.ImageUrl));
        }
        catch (TagExceptions e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Update existing tag
    /// </summary>
    /// <param name="id">Id of tag</param>
    /// <param name="tagViewModel">new data</param>
    /// <responce code = "200">Return updated tag</responce>
    [HttpPost("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TagViewModel tagViewModel)
    {
        try
        {
            return Ok(await _tagService.UpdateTag(id, tagViewModel.TagName, tagViewModel.ImageUrl));
        }
        catch (TagExceptions e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

}