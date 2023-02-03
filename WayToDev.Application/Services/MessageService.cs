using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class MessageService : Dao<Message>, IMessageService
{
    private readonly ISecurityContext _securityContext;
    private readonly IUserService _userService;
    
    public MessageService(ApplicationContext context, ISecurityContext securityContext, IUserService userService, IMapper mapper = null) : base(context, mapper)
    {
        _securityContext = securityContext;
        _userService = userService;
    }

    public async Task<MessageDto> Send(Guid chatId, string message)
    {
        var senderId = _userService.GetCurrentUserId();
        var room = Context.Rooms
            .Include(x=>x.Messages)
            .FirstOrDefault(x => x.Id == chatId);
        if (room == null)
            throw new MessagesExceptions("Room not found");
        
        var msg = Insert(new Message { RoomId = chatId, SenderId = senderId, Text = message });
        await Context.SaveChangesAsync();
        
        var res = Context.Messages.Include(x=>x.Sender).First(x => x.Id == msg.Id);
        return Mapper.Map<Message, MessageDto>(res);
    }
}