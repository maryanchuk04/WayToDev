namespace WayToDev.Core.DTOs;

public class RoomPreviewDto
{
    public Guid Id { get; set; }
    public MessageDto? LastMessage { get; set; }
    public string Title { get; set; }
    public UserDto User { get; set; }
}