using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

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
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_mapper.Map<List<NewsDto>, List<NewsViewModel>>(_newsService.GetNews()));
    }
    
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

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] NewsViewModel updatedNews)
    {
        try
        {
            updatedNews.Id = id;
            await _newsService.Update(_mapper.Map<NewsViewModel, NewsDto>(updatedNews));
            return Ok();
        }
        catch (NewsNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}