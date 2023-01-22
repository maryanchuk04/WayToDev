using WayToDev.Core.Enums;

namespace WayToDev.Core.Entities;

public class AccountToken : BaseEntity
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public string? ReplacedByToken { get; set; }
    public TokenType Type { get; set; } = TokenType.RefreshToken;
}