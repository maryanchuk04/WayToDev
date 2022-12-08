namespace WayToDev.Domain.Entities;

public class News : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public DateTime Date { get; } = DateTime.Now;
    public User User { get; set; }
    public Guid UserId { get; set; }
    public string Image { get; set; }
}