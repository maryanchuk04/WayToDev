using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class UserService : Dao<User>, IUserService
{
    private readonly ISecurityContext _securityContext;
    public UserService(ApplicationContext context, ISecurityContext securityContext, IMapper mapper = null) : base(context, mapper)
    {
        _securityContext = securityContext;
    }


    public UserDto GetCurrentUserInfo()
    {
        var userId = _securityContext.GetCurrentUserId();
        var user = Context.Users
            .Include(x => x.Account)
            .Include(x => x.Image)
            .FirstOrDefault(x=>x.Id == userId);

        if (user == null)
            throw new UserNotFoundException("User with this id is not found!");
        
        return Mapper.Map<User, UserDto>(user);
    }
}