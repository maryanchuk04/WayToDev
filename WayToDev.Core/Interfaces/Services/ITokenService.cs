using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(Account account);
    AccountToken GenerateRefreshToken();
    Task<AuthenticateResponseModel> RefreshToken(string token);
    Task<bool> RevokeToken(string token);
    Task<AccountToken> GenerateEmailConfirmationToken(Guid accountId);
}