using WayToDev.Core.Enums;

namespace WayToDev.Core.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public Gender? Gender { get; set; }
    public Account Account { get; set; }
    public Guid AccountId { get; set; }
    public Image? Image { get; set; }
}