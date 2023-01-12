using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

[ApiController]
[Route("api/company")]
[Authorize]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
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
}