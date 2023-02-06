using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IMessageService
{
    Task<MessageDto> Send(Guid chatId, string message);
}