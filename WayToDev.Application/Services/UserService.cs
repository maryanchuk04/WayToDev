using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class UserService : Dao<User>, IUserService
{
    private readonly ISecurityContext _context
    public UserService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }


    public UserDto GetCurrentUserInfo()
    {
        throw new NotImplementedException();
    }
}