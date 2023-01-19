using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

/// <summary>
/// API controller for company
/// </summary>
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
    
    /// <summary>
    /// Get Current company by token
    /// </summary>
    /// <returns>Company information</returns>
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

    
    /// <summary>
    /// Update all information about company
    /// </summary>
    /// <param name="companyViewModel">Company model which contain all info</param>
    /// <response code = '200'></response>
    [HttpPut]
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