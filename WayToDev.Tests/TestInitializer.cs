using AutoMapper;
using Moq;
using WayToDev.Db.EF;

namespace WayToDev.Tests;

[TestFixture]
public abstract class TestInitializer
{
    protected static Mock<IMapper> MockMapper { get; set; }

    protected ApplicationContext Context { get; set; }

    [SetUp]
    protected virtual void Initialize()
    {
        MockMapper = new Mock<IMapper>();
        var factory = new ConnectionFactory();
        Context = factory.CreateContextForInMemory();
    }

    [TearDown]
    protected virtual void Cleanup()
    {
        Context.Dispose();
    }
}