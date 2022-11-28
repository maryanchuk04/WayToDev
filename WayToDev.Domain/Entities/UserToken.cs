namespace WayToDev.Domain.Entities;

public class UserToken : BaseEntity
{
    public Guid AccountId { get; set; }

    public virtual Account Account { get; set; }

    public string Token { get; set; }

    public DateTime Expires { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Revoked { get; set; }

    public string? ReplacedByToken { get; set; }

}