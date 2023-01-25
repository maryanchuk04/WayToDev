using WayToDev.Core.Entities;
using WayToDev.Core.Interfaces.Managers;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Application.Managers;

public class AccountManager : IAccountManager
{
    private readonly IPasswordHelper _passwordHelper;

    public AccountManager(IPasswordHelper passwordHelper)
    {
        _passwordHelper = passwordHelper;
    }

    public Account CreateUserAccount(string userName, string email, string password)
    {
        return new Account
        {
            IsBlocked = false,
            Email = email,
            User = new User
            {
                UserName = userName,
                FirstName = userName,
                TechStack = new List<TechStack>()
            },
            RefreshTokens = new List<AccountToken>(),
            Password = _passwordHelper.HashPassword(password)
        };
    }

    public Account CreateCompanyAccount(string companyName, string email, string password)
    {
        return new Account
        {
            IsBlocked = false,
            Email = email,
            Company = new Company
            {
                CompanyName = companyName,
                TechStack = new List<TechStack>()
            },
            RefreshTokens = new List<AccountToken>(),
            Password = _passwordHelper.HashPassword(password)
        };
    }
}