namespace WayToDev.Core.Exceptions;

public class NewsNotFoundException : Exception
{
    public NewsNotFoundException(string message) : base(message)
    {
    }
}