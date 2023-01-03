namespace WayToDev.Core.DTOs;

public class RoomDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<MessageDto> Messages { get; set; }
    public List<UserDto> Users { get; set; }
}