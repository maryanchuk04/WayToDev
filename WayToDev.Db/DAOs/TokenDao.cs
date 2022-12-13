using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Db.Daos.Base;
using WayToDev.Core.Entities;
using WayToDev.Core.Interfaces.DAOs;

namespace WayToDev.Db.Daos;

public class TokenDao : Dao<AccountToken>, ITokenDao
{
    public TokenDao(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }


    public AccountToken GetRefreshToken(string token)
    {
        return Context.UserTokens.SingleOrDefault(x => x.Token == token);
    }

    public async Task Update(AccountToken accountToken)
    {
        base.Update(accountToken);
        await Context.SaveChangesAsync();
    }

    public Account GetAccountByToken(string token)
    {
        var account = Context.Accounts
            .Include(a => a.RefreshTokens)
            .SingleOrDefault(a => a.RefreshTokens.Any(t => t.Token.Equals(token)));
        return account;
    }
}