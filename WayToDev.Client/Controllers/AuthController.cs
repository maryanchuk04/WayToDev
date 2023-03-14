using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Application.Exceptions;
using WayToDev.Client.ExtensionMethods;
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
            var authResponseModel = await _authService.AuthenticateAsync(authenticateViewModel.Email, authenticateViewModel.Password);
            HttpContext.SetTokenCookie(authResponseModel);        
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
            if (await _authService.CanRegisterAsync(registerViewModel.Email))
            {
                throw new AuthenticateException("Account already exist");
            }
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
        
        return Ok(new { Token = authResponseModel.JwtToken, authResponseModel.Role });
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
            HttpContext.DeleteRefreshToken();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}