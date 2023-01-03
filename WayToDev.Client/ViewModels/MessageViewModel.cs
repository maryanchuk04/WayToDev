namespace WayToDev.Client.ViewModels;

public class MessageViewModel
{
    public string Text { get; set; }
    public Guid RoomId { get; set; }
    public DateTime When { get; set; }
    public UserShortInfoViewModel User { get; set; }
}