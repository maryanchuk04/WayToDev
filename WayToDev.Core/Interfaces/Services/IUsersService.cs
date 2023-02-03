using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IUsersService
{
    Task<List<UserDto>> GetUsers();
    Task<UserDto> GetUserByIdAsync(Guid id);
    List<UserDto> GetFilteredUsers(FilterViewModel filterViewModel, out int count);
}