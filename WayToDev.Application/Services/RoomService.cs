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
    private readonly IUserService _userService;
    public RoomService(ApplicationContext context, ISecurityContext securityContext, IUserService userService, IMapper mapper = null) : base(context, mapper)
    {
        _securityContext = securityContext;
        _userService = userService;
    }

    public async Task<RoomDto> GetRoom(Guid chatId, Guid userId)
    {
        var currentUserId = _userService.GetCurrentUserId();

        if (!Context.Rooms.Any(x=>x.Id == chatId))
            return await CreateRoom(userId);

        var res = Context.Rooms
            .Include(x=>x.UserRooms)
                .ThenInclude(x=>x.User)
            .Include(c => c.Messages)
                .ThenInclude(x=>x.Sender)
                    .ThenInclude(x=>x.Image)
            .FirstOrDefault(x => x.Id == chatId);
        
        if (res == null)
            throw new MessagesExceptions("Messages Exceptions");
        
        return Mapper.Map<Room, RoomDto>(res);
    }

    public async Task<List<RoomPreviewDto>> GetUserRooms()
    {
        var rooms = Context.Rooms
            .Include(x=>x.UserRooms)
                .ThenInclude(x=>x.User)
            .Where(x => x.UserRooms.Any(u => u.User.AccountId == _securityContext.GetCurrentAccountId()));

        if (!rooms.Any())
        {
            return new List<RoomPreviewDto>();
        }

        var res = await rooms.Include(x => x.Messages)
            .Include(x => x.UserRooms)
                .ThenInclude(x => x.User)
                        .ThenInclude(x=>x.Image)
            .ToListAsync();

        foreach (var item in res)
        {
            item.UserRooms = item.UserRooms.Where(x => x.UserId != _userService.GetCurrentUserId()).ToList();
        }
        
        return Mapper.Map<List<Room>, List<RoomPreviewDto>>(res);
    }

    public async Task<RoomDto> CreateRoom(Guid userId)
    {
        var currentUserId = _userService.GetCurrentUserId();
        
        if (Context.Rooms.Any(x => x.UserRooms
                .Any(userRoom => userRoom.UserId == currentUserId && userRoom.UserId == userId)))
        {
            throw new RoomsException("Chat is already exist");
        }

        var room = new Room()
        {
            Messages = new List<Message>(),
            Id = Guid.NewGuid()
        };
        room.Title = $"{Context.Users.FirstOrDefault(x => x.Id == userId).UserName} and {Context.Users.FirstOrDefault(x => x.Id == currentUserId).UserName} chat";
        
        room.UserRooms = new List<UserRoom>()
        {
            new() { UserId = currentUserId, RoomId = room.Id, Room = room},
            new() { UserId = userId, RoomId = room.Id, Room = room },
        };

        Insert(room);
        await Context.SaveChangesAsync();
        
        
        return Mapper.Map<Room, RoomDto>(room);
    }
}