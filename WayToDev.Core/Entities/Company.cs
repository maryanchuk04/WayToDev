namespace WayToDev.Core.Entities;

public class Company : BaseEntity
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }
    public string Description { get; set; }
}