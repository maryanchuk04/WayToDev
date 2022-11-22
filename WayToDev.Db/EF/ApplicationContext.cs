using Microsoft.EntityFrameworkCore;

namespace WayToDev.Db.EF;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
    {
    }
}