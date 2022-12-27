using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

/// <summary>
/// User api controller
/// </summary>
[Authorize]
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Get current authorized user information
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetCurrentUser()
    {
        try
        {
            return Ok(_userService.GetCurrentUserInfo());
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}