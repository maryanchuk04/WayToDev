namespace WayToDev.Core.DTOs;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
    public List<TagDto>? Tags { get; set; }
    public List<FeedbackDto>? Feedbacks { get; set; }
    public string? BannerImage { get; set; }
    public string WebsiteLink { get; set; }
    public int CountOfWorkers { get; set; }
}