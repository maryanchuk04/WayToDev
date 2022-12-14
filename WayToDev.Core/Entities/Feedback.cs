namespace WayToDev.Core.Entities;

public class Feedback : BaseEntity
{
    public string Text { get; set; }
    public int Rate { get; set; }
    public bool IsApproved { get; set; } = false;
    public Guid UserId { get; set; }
}