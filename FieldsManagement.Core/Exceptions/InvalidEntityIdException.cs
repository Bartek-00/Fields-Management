namespace FieldsManagement.Core.Exceptions;

public class InvalidEntityIdException : BaseException
{
    public InvalidEntityIdException() : base("This isn't correct EntityId")
    {
    }
}