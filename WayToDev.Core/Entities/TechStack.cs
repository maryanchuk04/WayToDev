namespace WayToDev.Core.Entities;

public class TechStack : BaseEntity
{
    public User User { get; set; }
    public Tag Tag { get; set; }
    //maybe add description for every tag
}