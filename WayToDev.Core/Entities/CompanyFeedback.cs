namespace WayToDev.Core.Entities;

public class CompanyFeedback : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    public Guid FeedbackId { get; set; }
    public Feedback Feedback { get; set; }
}