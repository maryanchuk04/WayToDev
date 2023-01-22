using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Application.Exceptions;
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
            var authResponseModel = await _authService.Authenticate(authenticateViewModel.Email, authenticateViewModel.Password);
            

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
            var result = await _authService.Registration(_mapper.Map<RegistrViewModel, RegistrDto>(registerViewModel));
            RefreshCookie(result);
            await _mailService.SendRegistrationMessageAsync(registerViewModel.Email, Url.Action("EmailConfirm", "Auth", result.JwtToken));
            return Ok(new { Token = result.JwtToken });
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
    [HttpPost("verify/{accountId}/{token}")]
    public async Task<IActionResult> EmailConfirm(string accountId, string token)
    {
        if (!Guid.TryParse(accountId, out Guid id))
        {
            throw new AuthenticateException("User not found");
        }

        var authResponseModel = await _authService.EmailConfirmAndAuthenticate(id, token);

        RefreshCookie(authResponseModel);
        return Ok(new { Token = authResponseModel.JwtToken });
    }

    private void RefreshCookie(AuthenticateResponseModel authResponseModel)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(7),
            Secure = true,
        };

        HttpContext.Response.Cookies.Delete("refreshToken");
        HttpContext.Response.Cookies.Append("refreshToken", authResponseModel.RefreshToken, cookieOptions);
    }
}