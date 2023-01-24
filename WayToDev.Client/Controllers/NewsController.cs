using AutoMapper;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

/// <summary>
/// News api controller
/// </summary>
[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;
    private readonly IMapper _mapper;
    
    public NewsController(INewsService newsService, IMapper mapper)
    {
        _newsService = newsService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Get method for get all data about news
    /// </summary>
    /// <returns>200 - with List of News</returns>
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_mapper.Map<List<NewsDto>, List<NewsViewModel>>(_newsService.GetNews()));
    }
    //[HttpGet]
    //public IActionResult Get()
    //{
    //    return Ok(_mapper.Map<List<NewsDto>, List<NewsViewModel>>(_newsService.GetNews()));
    //}
    
    /// <summary>
    /// Get news by id
    /// </summary>
    /// <param name="id">News id</param>
    /// <returns>200-with news or 400 with error</returns>
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            return Ok(_mapper.Map<NewsDto, NewsViewModel>(_newsService.GetNewsById(id)));
        }
        catch (NewsNotFoundException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    [HttpGet]
    public IActionResult GetFilteredNews([FromQuery] NewsFilterViewModel model)
    {
        try
        {
            IndexViewModel<NewsDto> newsResult = new()
            {
                Items = _newsService.GetFilteredNews(model, out int count),
                PageViewModel = new PageViewModel(count, model.Page, model.PageSize)
            };
            return Ok(newsResult);
        }
        catch (NewsNotFoundException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Insert new news in table
    /// </summary>
    /// <param name="newsViewModel">News Model, contains all data about new news</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NewsViewModel newsViewModel)
    {
        try
        {
            var res = await _newsService.Create(_mapper.Map<NewsViewModel, NewsDto>(newsViewModel));
            return CreatedAtAction(nameof(Get), new {id = res.Id}, res);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Delete news from table
    /// </summary>
    /// <param name="id">Id of news, what you want remove</param>
    /// <returns>204 - if deleted</returns>
    /// <response code="204">All good and delete</response>
    /// <response code="400">Returns 400 and Error model with message</response>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _newsService.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Update news data
    /// </summary>
    /// <param name="id">id of news</param>
    /// <param name="updatedNews">updated date about news</param>
    /// <returns>Ok - if update</returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] NewsViewModel updatedNews)
    {
        try
        {
            var dto = _mapper.Map<NewsViewModel, NewsDto>(updatedNews);
            dto.Id = id;
            await _newsService.Update(dto);
            return Ok();
        }
        catch (NewsNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}