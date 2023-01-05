using System.ComponentModel.DataAnnotations.Schema;

namespace WayToDev.Core.Entities;

[Table("News")]
public class News : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public Image? Image { get; set; }
    public Guid ImageId { get; set; }
}