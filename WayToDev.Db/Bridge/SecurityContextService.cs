using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Db.Bridge;

public class SecurityContextService : ISecurityContext
{
    private readonly IHttpContextAccessor _HttpContextAccessor;

    public SecurityContextService(IHttpContextAccessor httpContextAccessor)
    {
        _HttpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        Claim guidClaim = _HttpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name);

        if(guidClaim == null || !Guid.TryParse(guidClaim.Value, out  var result))
        {
            throw new Exception("User not found");
        }

        return result;
    }
}