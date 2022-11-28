using WayToDev.Domain.Entities;

namespace WayToDev.Domain.Interfaces.DAOs;

public interface IAccountDao
{
    Task Update(Account account);
}