using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.Services;

public interface IRoomService
{
    Task<RoomDto> GetRoom(Guid chatId, Guid senderId);
    Task<List<RoomPreviewDto>> GetUserRooms();
    Task<RoomDto> CreateRoom(Guid userId);
}