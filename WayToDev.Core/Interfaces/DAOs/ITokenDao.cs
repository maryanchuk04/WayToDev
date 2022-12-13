using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.DAOs;

public interface ITokenDao
{
    AccountToken GetRefreshToken(string token);
    Task Update(AccountToken accountToken);
    Account GetAccountByToken(string token);
}