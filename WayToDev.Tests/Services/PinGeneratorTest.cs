using WayToDev.Application.Services;

namespace WayToDev.Tests.Services;

[TestFixture]
public class PinGeneratorTest
{
    private PinGenerator generator;
    
    [SetUp]
    public void Initialize()
    {
        generator = new PinGenerator();
    }

    [Test]
    public void Should_Return_RandomNumber()
    {
        var res = generator.Generate();
        Assert.That(res.GetType(), Is.EqualTo(typeof(int)));
    }
    
    [Test]
    public void Should_Return_NotNegative()
    {
        var res = generator.Generate();
        Assert.That(res, Is.Not.Negative);
    }
}