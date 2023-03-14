namespace WayToDev.Core.Interfaces.Services;

public interface ISecurityContext
{
    Guid GetCurrentAccountId();
}