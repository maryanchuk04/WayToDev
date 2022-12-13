namespace WayToDev.Core.Entities;

public class Feedback : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Text { get; set; }
    public int Rate { get; set; }
    public bool IsApproved { get; set; } = false;
}