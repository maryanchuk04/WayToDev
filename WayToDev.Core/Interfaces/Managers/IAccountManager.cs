using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.Managers;

public interface IAccountManager
{
    Account CreateUserAccount(string userName, string email, string password);
    Account CreateCompanyAccount(string companyName, string email, string password);
}