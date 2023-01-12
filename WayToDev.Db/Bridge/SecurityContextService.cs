using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Db.Bridge;

public class SecurityContextService : ISecurityContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SecurityContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentAccountId()
    {
        var guidClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name);

        if(guidClaim == null || !Guid.TryParse(guidClaim.Value, out var result))
        {
            throw new Exception("Account not found");
        }

        return result;
    }
}