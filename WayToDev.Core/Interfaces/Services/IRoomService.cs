using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.Services;

public interface IRoomService
{
    Task<RoomDto> GetRoom(Guid chatId, Guid userId);
    Task<List<RoomPreviewDto>> GetUserRooms();
    Task<RoomDto> CreateRoom(Guid userId);
}