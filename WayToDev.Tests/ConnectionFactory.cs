using Microsoft.EntityFrameworkCore;
using WayToDev.Db.EF;

namespace WayToDev.Tests;

public sealed class ConnectionFactory : IDisposable
{
    private bool disposedValue = false;

    public ApplicationContext CreateContextForInMemory()
    {
        var option = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "WayToDev").Options;
        var context = new ApplicationContext(option);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return context;
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }
}