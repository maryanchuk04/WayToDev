namespace WayToDev.Client.ViewModels;

public class NewsViewModel
{
   public Guid Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public DateTime Date { get; } = DateTime.Now;
    public string Image { get; set; }
    public string Text { get; set; }
}