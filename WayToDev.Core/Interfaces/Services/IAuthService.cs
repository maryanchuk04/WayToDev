using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IAuthService
{
    Task<AuthenticateResponseModel> Authenticate(string email, string password);
    Task<AuthenticateResponseModel> Registration(RegistrDto registrationDto);
}
