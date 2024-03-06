namespace FieldsManagement.Core.Exceptions;

public sealed class InvalidNameException : BaseException
{
    public InvalidNameException() : base("This isn't correct Name")
    {
    }
}