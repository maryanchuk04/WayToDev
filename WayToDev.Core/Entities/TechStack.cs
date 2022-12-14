namespace WayToDev.Core.Entities;

public class TechStack : BaseEntity
{
    public ICollection<Tag> TechTags { get; set; }
}