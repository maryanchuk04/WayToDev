using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WayToDev.Core.Interfaces.Services;

public interface ISecurityContext
{
    Guid GetCurrentUserId();
}