using Microsoft.EntityFrameworkCore;
using WayToDev.Core.Entities;

namespace WayToDev.Db;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountToken> UserTokens { get; set; }
    public DbSet<News> NewsSet { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<CompanyFeedback> CompanyFeedbacks { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<UserRoom> UserRooms { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Message> Messages { get; set; }

}