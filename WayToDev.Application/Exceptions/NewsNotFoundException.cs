namespace WayToDev.Application.Exceptions;

public class NewsNotFoundException : Exception
{
    public NewsNotFoundException(string message) : base(message)
    {
    }
}