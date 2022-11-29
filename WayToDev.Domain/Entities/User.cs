using WayToDev.Domain.Enums;

namespace WayToDev.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public Gender? Gender { get; set; }
    public Account Account { get; set; }
}