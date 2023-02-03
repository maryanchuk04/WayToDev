using WayToDev.Core.Enums;

namespace WayToDev.Core.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public Gender? Gender { get; set; }
    public string ImageUrl { get; set; }
    public List<TagDto> Tags { get; set; }
}