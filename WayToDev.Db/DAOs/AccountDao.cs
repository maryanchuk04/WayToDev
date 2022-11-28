using AutoMapper;
using WayToDev.Db.Daos.Base;
using WayToDev.Domain.Entities;
using WayToDev.Domain.Interfaces.DAOs;

namespace WayToDev.Db.Daos;

public class AccountDao : Dao<Account>, IAccountDao
{
    public AccountDao(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }

    public async Task Update(Account account)
    {
        base.Update(account);
        await Context.SaveChangesAsync();
    }
}