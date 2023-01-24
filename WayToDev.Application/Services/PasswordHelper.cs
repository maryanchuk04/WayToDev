using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Application.Services;

public class PasswordHelper: IPasswordHelper
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    
    public bool VerifyPassword(string incomingPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(incomingPassword,password);
    }
}