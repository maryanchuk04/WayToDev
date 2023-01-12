namespace WayToDev.Core.DTOs;

public class FeedbackDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public int Rate { get; set; }
    public bool IsApproved { get; set; } = false;
    public Guid UserId { get; set; }
}