namespace WayToDev.Core.Entities;

public class Company : BaseEntity
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public string CompanyName { get; set; }
    public Guid? ImageId { get; set; }
    public Image? Image { get; set; }
    public string? Description { get; set; }
    public ICollection<CompanyFeedback>? Feedbacks { get; set; }
    public TechStack? TechStack { get; set; }
    public Guid? TechStackId { get; set; }
}