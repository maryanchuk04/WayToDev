namespace WayToDev.Core.Exceptions;

public class DataAccessException : Exception
{
    public DataAccessException(string message) : base(message)
    {
    }
}