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
    private readonly IMailService _mailService;
    public AuthController(IAuthService authService, IMapper mapper, IMailService mailService)
    {
        _authService = authService;
        _mapper = mapper;
        _mailService = mailService;
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
            await _mailService.SendRegistrationMessageAsync(registerViewModel.Email, result);
            return Ok();
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
    [HttpGet("verify/{token}")]
    public async Task<IActionResult> EmailConfirm(string token)
    {
        var authResponseModel = await _authService.EmailConfirmAndAuthenticateAsync(token);
        HttpContext.SetTokenCookie(authResponseModel);
        return Ok(authResponseModel);
    }
}