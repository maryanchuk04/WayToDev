using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

[Authorize]
[ApiController]
[Route("api/company")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;
    
    public CompanyController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCurrentCompany()
    {
        try
        {
            return Ok(_companyService.GetCurrentCompany());
        }
        catch (CompanyExceptions e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCurrentCompany([FromBody] CompanyViewModel companyViewModel)
    {
        try
        {
            await _companyService.UpdateCompany(_mapper.Map<CompanyViewModel, CompanyDto>(companyViewModel));
            return Ok();
        }
        catch (CompanyExceptions e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}