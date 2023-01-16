using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

[ApiController]
[Route("/api/vacancy")]
public class VacancyController : ControllerBase
{
    private readonly IVacancyService _vacancyService;
    private readonly IMapper _mapper;
    public VacancyController(IVacancyService vacancyService, IMapper mapper)
    {
        _vacancyService = vacancyService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_vacancyService.GetAllVacancies());
        }
        catch (VacancyException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateVacancy(VacancyCreateDto vacancy)
    {
        try
        {
            var res = await _vacancyService.CreateVacancy(vacancy);
            return CreatedAtAction(nameof(GetAll), new {id = res.Id}, res);
        }
        catch (VacancyException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_vacancyService.GetById(id));
        }
        catch (VacancyException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}