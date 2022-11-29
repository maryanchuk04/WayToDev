namespace WayToDev.Domain.Entities;

public class Account : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Password { get; set; }
    public bool IsBlocked { get; set; }
    public ICollection<UserToken> RefreshTokens { get; set; }
}