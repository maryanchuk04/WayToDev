namespace WayToDev.Core.DTOs;

public class MessageDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime When { get; set; } = DateTime.Now;
    public Guid SenderId { get; set; }
    public UserDto Sender { get; set; }
    public Guid RoomId { get; set; }
}