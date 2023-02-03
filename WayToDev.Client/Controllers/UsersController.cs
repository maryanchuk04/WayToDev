using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    /// <summary>
    /// Get users by query
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get([FromQuery] FilterViewModel model)
    {
        try
        {
            IndexViewModel<UserDto> usersRes = new()
            {
                Items = _usersService.GetFilteredUsers(model, out var count),
                PageViewModel = new PageViewModel(count, model.Page, model.PageSize)
            };
            return Ok(usersRes);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            return Ok(await _usersService.GetUserByIdAsync(id));
        }   
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}