using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Application.Exceptions;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Interfaces.Services;


namespace WayToDev.Client.Controllers;

/// <summary>
/// Authenticate Api controller
/// </summary>
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

    /// <summary>
    /// This method login user in application
    /// </summary>
    /// <param name="authenticateViewModel">Model which contain email and password</param>
    /// <returns>JWT token and generate refreshToken</returns>
    /// <response code="200">All good</response>
    /// <response code="400">Returns 400 and Error model with message</response>
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
    
    /// <summary>
    /// This method registration new user in system.
    /// </summary>
    /// <param name="registerViewModel">Model which contain basic data for creating account</param>
    /// <returns>Ok with JWT token</returns>
    /// <response code="200">All good</response>
    /// <response code="400">Returns 400 and Error model with message</response>
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
    
    /// <summary>
    /// UnAuthorize user
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public IActionResult UnAuthorize()
    {
        try
        {
            HttpContext.Response.Cookies.Delete("refreshToken");
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}