namespace WayToDev.Core.Interfaces.Services;

public interface IPinGenerator
{
    public int Min { get; }
    public int Max { get; }
    public int Generate();
}