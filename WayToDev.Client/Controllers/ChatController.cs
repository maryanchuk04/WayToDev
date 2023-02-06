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
    public async Task<IActionResult> Get()
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
    /// Start new chat with user
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> StartChat(Guid id)
    {
        try
        {
            var res = await _roomService.CreateRoom(id);
            return CreatedAtAction(nameof(Get), new {id = res.Id}, res);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }

    /// <summary>
    /// Get Chat By id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/{userId}")]
    public async Task<IActionResult> GetChat(Guid id, Guid userId)
    {
        try
        {
            return Ok(await _roomService.GetRoom(id, userId));
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponseModel(e.Message));
        }
    }
}