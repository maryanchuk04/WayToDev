namespace WayToDev.Core.Entities;

public class UserRoom : BaseEntity
{
    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}