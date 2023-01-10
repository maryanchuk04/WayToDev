using AutoMapper;
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
            var authResponseModel = await _authService.Authenticate(authenticateViewModel.Email, authenticateViewModel.Password);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7),
                Secure = true,
            };

            HttpContext.Response.Cookies.Delete("refreshToken");
            HttpContext.Response.Cookies.Append("refreshToken", authResponseModel.RefreshToken, cookieOptions);

            return Ok(new { Token = authResponseModel.JwtToken, authResponseModel.Role });
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
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7),
                Secure = true,
            };

            HttpContext.Response.Cookies.Delete("refreshToken");
            HttpContext.Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);
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
}