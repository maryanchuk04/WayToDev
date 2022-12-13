namespace WayToDev.Core.Entities;

public class Account : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Password { get; set; }
    public bool IsBlocked { get; set; }
    public ICollection<AccountToken> RefreshTokens { get; set; }
}