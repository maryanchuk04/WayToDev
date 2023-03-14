using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IMessageService
{
    Task<MessageDto> Send(Guid chatId,Guid senderId, string message);
    
    Task<RoomDto> GetRoom(Guid chatId, Guid senderId);
}