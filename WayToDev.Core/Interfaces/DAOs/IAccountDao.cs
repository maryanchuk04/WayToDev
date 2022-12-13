using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.DAOs;

public interface IAccountDao
{
    Task Update(Account account);
    Task Create(Account account);
    Task Delete(Guid id);
    Account FindById(Guid id);
    Account FindByEmail(string email);
    bool IsExist(string email);
}