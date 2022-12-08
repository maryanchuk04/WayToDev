using WayToDev.Domain.Entities;

namespace WayToDev.Domain.Interfaces.DAOs;

public interface ITokenDao
{
    UserToken GetRefreshToken(string token);
    Task Update(UserToken userToken);
    Account GetAccountByToken(string token);
}