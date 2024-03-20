namespace FieldsManagement.Core.Exceptions;

public class InvalidPasswordException : BaseException
{
    public InvalidPasswordException() : base("This isn't correct password")
    {
    }
}