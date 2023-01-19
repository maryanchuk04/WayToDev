using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Enums;

namespace WayToDev.Core.Interfaces.Services;

public interface IUserService
{
    UserDto GetCurrentUserInfo();
    Task AddTechnologyTags(List<Guid> tagsIds);
    Task UpdateUserInfo(string userName, string firstName, string lastName, DateTime birthday, string imageUrl,
        Gender? gender, List<TagDto> tagDtos);
    void UpdateUserTechnologies(IEnumerable<Guid> technologiesIds, User user);
    UserDto GetUserById(Guid id);
}