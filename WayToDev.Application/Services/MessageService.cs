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
    public MessageService(ApplicationContext context, ISecurityContext securityContext, IMapper mapper = null) : base(context, mapper)
    {
        _securityContext = securityContext;
    }

    public async Task<MessageDto> Send(Guid chatId, Guid senderId, string message)
    {
        var room = Context.Rooms
            .FirstOrDefault(x => x.Id == chatId) 
                   ?? Context.Rooms
            .First(x => x.UserRooms.Count == 2 
                        && x.UserRooms.Any(y => y.UserId == chatId) 
                        && x.UserRooms.Any(y => y.UserId == senderId));
        
        var msg = Insert(new Message { RoomId = room.Id, SenderId = senderId, Text = message });
        await Context.SaveChangesAsync();
        
        var res = Context.Messages.Include(x=>x.User).First(x => x.Id == msg.Id);
        return Mapper.Map<Message, MessageDto>(res);
    }
}