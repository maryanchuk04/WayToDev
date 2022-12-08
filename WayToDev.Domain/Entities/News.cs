using System.ComponentModel.DataAnnotations.Schema;

namespace WayToDev.Domain.Entities;

[Table("News")]
public class News : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; } = DateTime.Now;
    public Guid UserId { get; set; }
    public string Image { get; set; }
}