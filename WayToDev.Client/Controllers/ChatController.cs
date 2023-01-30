using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WayToDev.Client.ViewModels;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Controllers;

/// <summary>
/// Chat api controller
/// </summary>
[ApiController]
[Authorize]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IRoomService _roomService;
    
    public ChatController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    /// <summary>
    /// Get all users active chats
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUsersChats()
    {
        try
        {
            return Ok(await _roomService.GetUserRooms());
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
    
    /// <summary>
    /// Get all users active chats
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserChat(Guid id)
    {
        try
        {
            //await _messageService.GetRoom(id)
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}