using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Application.Exceptions;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
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
            return BadRequest(new
            {
                error = e.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NewsViewModel newsViewModel)
    {
        try
        {
            await _newsService.Create(_mapper.Map<NewsViewModel, NewsDto>(newsViewModel));
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                error = e.Message
            });
        }
    }
}