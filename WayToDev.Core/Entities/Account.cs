namespace WayToDev.Core.Entities;

public class Account : BaseEntity
{
    public User? User { get; set; }
    public Company? Company { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsBlocked { get; set; }
    public ICollection<AccountToken> RefreshTokens { get; set; }
}