namespace WayToDev.Core.Entities;

public class Image : BaseEntity
{
    public Image(string imageUrl)
    {
        ImageUrl = imageUrl;
    }

    public string ImageUrl { get; set; }
}