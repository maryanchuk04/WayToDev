namespace WayToDev.Domain.DTOs;

public class NewsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public DateTime Date { get; set; }
    public string Image { get; set; }
    public string Text { get; set; }
}