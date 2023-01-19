using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
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
    private readonly IMapper _mapper;
    
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
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

    /// <summary>
    /// Change information about user
    /// </summary>
    /// <param name="userInfoView">Model contain all information about user</param>
    /// <response code = "200">Success</response>
    /// <response code = "400">Something happened</response>
    [HttpPut]
    public async Task<IActionResult> UpdateUserInformation([FromBody] UserInfoViewModel userInfoView)
    {
        try
        {
            await _userService.UpdateUserInfo(
                userInfoView.UserName,
                userInfoView.FirstName,
                userInfoView.LastName,
                userInfoView.Birthday,
                userInfoView.ImageUrl ?? "",
                userInfoView.Gender,
                _mapper.Map<List<TagViewModel>, List<TagDto>>(userInfoView.Tags)
            );
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id">id of user</param>
    /// <returns>user</returns>
    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        try
        {
            return Ok(_userService.GetUserById(id));
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

}