using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IUserService
{
    UserDto GetCurrentUserInfo();
}