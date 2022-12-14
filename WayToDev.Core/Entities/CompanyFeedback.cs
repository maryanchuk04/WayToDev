namespace WayToDev.Core.Entities;

public class CompanyFeedback : BaseEntity
{
    public Feedback Feedback{ get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}