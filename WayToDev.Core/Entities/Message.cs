namespace WayToDev.Core.Entities;

public class Message : BaseEntity
{
    public string Text { get; set; }
    public DateTime When { get; } = DateTime.Now;
    public User Sender { get; set; }
    public Guid SenderId { get; set; }
    public Guid RoomId { get; set; }
   
}