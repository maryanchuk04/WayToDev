namespace WayToDev.Core.Interfaces.Services;

public interface IPasswordHelper
{
    string HashPassword(string password);
    bool VerifyPassword(string incomingPassword, string password);
}