using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Application.Exceptions;
using WayToDev.Client.ExtensionMethods;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Interfaces.Services;


namespace WayToDev.Client.Controllers;

[ApiController]
[Route("api/authenticate")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthenticateViewModel authenticateViewModel)
    {
        try
        {
            var authResponseModel = await _authService.AuthenticateAsync(authenticateViewModel.Email, authenticateViewModel.Password);
            HttpContext.SetTokenCookie(authResponseModel);        
            return Ok(new { Token = authResponseModel.JwtToken });
        }
        catch (AuthenticateException e)
        {
            return BadRequest(new
            {
                error = e.Message
            });
        }
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrViewModel registerViewModel)
    {
        try
        {
            var result = await _authService.RegistrationAsync(_mapper.Map<RegistrViewModel, RegistrDto>(registerViewModel));
            return Ok(new { accountId = result});
        }
        catch (AuthenticateException e)
        {
            return BadRequest(new
            {
                error = e.Message
            });
        }
    }

    [AllowAnonymous]
    [HttpGet("verify/{accountId}/{token}")]
    public async Task<IActionResult> EmailConfirm(Guid accountId, string token)
    {
        var authResponseModel = await _authService.EmailConfirmAndAuthenticateAsync(token, accountId);
        HttpContext.SetTokenCookie(authResponseModel);
        
        return Ok(new { Token = authResponseModel.JwtToken });
    }
}