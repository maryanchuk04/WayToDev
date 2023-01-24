namespace WayToDev.Core.Interfaces.Services;

public interface IMailService
{
    Task SendRegistrationMessageAsync(string email, string token);
}