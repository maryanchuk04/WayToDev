using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IAuthService
{
    Task<AuthenticateResponseModel> AuthenticateAsync(string email, string password);
    Task<string> RegistrationAsync(RegistrDto registrationDto);
    Task<AuthenticateResponseModel> EmailConfirmAndAuthenticateAsync(string token, Guid accountId);
}
