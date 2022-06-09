namespace Day58Demo.Models.Services.Exceptions;

public class EntityMissingException : Exception
{
    public EntityMissingException(string message) : base(message)
    {
    }
}