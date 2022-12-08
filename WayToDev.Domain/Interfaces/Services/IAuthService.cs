using WayToDev.Domain.DTOs;

namespace WayToDev.Domain.Interfaces.Services;

public interface IAuthService
{
    Task<AuthenticateResponseModel> Authenticate(string email, string password);
    Task<AuthenticateResponseModel> Registration(RegistrDto registrationDto);
}
