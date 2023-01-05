namespace WayToDev.Client.ViewModels;

public class IndexViewModel<T>
{
    public IEnumerable<T> Items { get; set; }
    public PageViewModel PageViewModel { get; set; }
}