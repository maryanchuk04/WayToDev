namespace WayToDev.Core.Entities;

public class Article : BaseEntity
{
    public string Text { get; set; }
    public string Theme { get; set; }
    public Guid ImageId { get; set; }
    public Image? Image { get; set; }
    public string ShortDescription { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public bool IsApproved { get; set; }
}