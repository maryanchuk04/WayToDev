using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Application.Services;

public class PinGenerator : IPinGenerator
{ 
    int IPinGenerator.Min => 0;
    int IPinGenerator.Max => 9999;
    private readonly Random _random = new();
    
    public int Generate()
    {
        return _random.Next(((IPinGenerator)this).Min, ((IPinGenerator)this).Max);
    }
}