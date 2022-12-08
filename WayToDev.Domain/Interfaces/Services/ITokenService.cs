using WayToDev.Domain.DTOs;
using WayToDev.Domain.Entities;

namespace WayToDev.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(Account account);
    UserToken GenerateRefreshToken();
    Task<AuthenticateResponseModel> RefreshToken(string token);
    Task<bool> RevokeToken(string token);
}