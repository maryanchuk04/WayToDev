using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Application.Exceptions;
using WayToDev.Db.Daos.Base;
using WayToDev.Core.Entities;
using WayToDev.Core.Interfaces.DAOs;

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

    public async Task Create(Account account)
    {
        Insert(account);
        await Context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var account = Context.Accounts.FirstOrDefault(x => x.Id == id);
        if (account == null)
        {
            throw new AccountNotFoundException("Account is not Exist");
        }

        Delete(account);
        await Context.SaveChangesAsync();
    }

    public Account FindById(Guid id)
    {
        var account = Context.Accounts
            .Include(x=>x.RefreshTokens)
            .Include(x=>x.User)
            .FirstOrDefault(x => x.Id == id);
        
        if (account == null)
        {
            throw new AccountNotFoundException("Account not found");
        }
        
        return account;
    }

    public Account FindByEmail(string email)
    {
        var account = Context.Accounts
            .Include(x=>x.User)
            .Include(x=>x.RefreshTokens)
            .FirstOrDefault(x => x.User.Email == email);
        
        if (account == null)
        {
            throw new AccountNotFoundException("Account not found");
        }

        return account;
    }

    public bool IsExist(string email) => 
        Context.Accounts.Include(x=>x.User)
            .Any(x => x.User.Email == email);
  
}