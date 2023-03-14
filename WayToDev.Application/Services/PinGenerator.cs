using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Application.Services;

public class PinGenerator : IPinGenerator
{ 
    int IPinGenerator.Min { get; set; } = 0;
    int IPinGenerator.Max { get; set; } = 9999;
    private readonly Random _random = new Random();
    
    public int Generate()
    {
        return _random.Next(((IPinGenerator)this).Min, ((IPinGenerator)this).Max);
    }
}