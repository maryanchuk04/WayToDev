using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class RoomService : Dao<Room>, IRoomService
{
    private readonly ISecurityContext _securityContext;
    
    public RoomService(ApplicationContext context, ISecurityContext securityContext, IMapper mapper = null) : base(context, mapper)
    {
        _securityContext = securityContext;
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

    public async Task<List<RoomPreviewDto>> GetUserRooms()
    {
        var rooms = await Context.Rooms
            .Include(x => x.UserRooms)
                .ThenInclude(x => x.User)
            .Include(m => m.Messages)
            .Where(x => x.UserRooms.Any(u => u.User.AccountId == _securityContext.GetCurrentAccountId()))
            .ToListAsync();

        return Mapper.Map<List<Room>, List<RoomPreviewDto>>(rooms);
    }

    public async Task<RoomDto> CreateRoom(Guid userId)
    {
        var currentUserId = _securityContext.GetCurrentAccountId();
        if (Context.Rooms
            .Include(x=>x.UserRooms)
            .ThenInclude(x=>x.User)
            .Any(x => x.UserRooms.Any(
                userRoom => userRoom.User.AccountId == currentUserId 
                            && userRoom.UserId == userId))
            )
        {
            throw new RoomsException("Chat is already exist");
        }
        
        var room = new Room();
        room.UserRooms = new List<UserRoom>()
        {
            new() {Room = room, UserId = currentUserId},
            new() {Room = room, UserId = userId}
        };

        Context.Rooms.Add(room);
        await Context.SaveChangesAsync();

        return Mapper.Map<Room, RoomDto>(room);
    }
}