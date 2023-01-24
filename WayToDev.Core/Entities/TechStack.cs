namespace WayToDev.Core.Entities;

public class TechStack : BaseEntity
{
    public Tag Tag { get; set; }
    public User? User { get; set; }
    public Company? Company { get; set; }
}