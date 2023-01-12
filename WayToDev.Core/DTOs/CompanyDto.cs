namespace WayToDev.Core.DTOs;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public List<TagDto>? Tags { get; set; }
    public List<FeedbackDto>? Feedbacks { get; set; }
}