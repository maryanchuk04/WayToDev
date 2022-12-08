using Microsoft.EntityFrameworkCore;
using WayToDev.Domain.Entities;

namespace WayToDev.Db;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<News> NewsSet { get; set; }
    
}