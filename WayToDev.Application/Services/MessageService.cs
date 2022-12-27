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
    public MessageService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
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

    public async Task<RoomDto> GetRoom(Guid chatId, Guid senderId)
    {
        var room = Context.Rooms
                       .FirstOrDefault(x => x.Id == chatId) ??
                   Context.Rooms
                       .FirstOrDefault(x =>
                           x.UserRooms.Count == 2 &&
                           x.UserRooms.Any(y => y.UserId == chatId) &&
                           x.UserRooms.Any(y => y.UserId == senderId));

        if (room == null)
        {
            var temp = Context.Users.FirstOrDefault(x => x.Id == chatId);
            room = new Room()
            {
                Title = temp?.FirstName + " " + temp?.LastName
            };
            
            room.UserRooms = new List<UserRoom>
            {
                new() { Room = room, UserId = senderId },
                new() { Room = room, UserId = chatId },
            };
            Context.Rooms.Add(room);
            await Context.SaveChangesAsync();
        }
        
        var res = Context.Rooms
            .Include(c => c.Messages.OrderByDescending(x=>x.When).Take(20))
                .ThenInclude(x=>x.User)
            .FirstOrDefault(x => x.Id == room.Id);

        if (res == null)
            throw new MessagesExceptions("Messages Exceptions");
        
        return Mapper.Map<Room, RoomDto>(res);
    }
}