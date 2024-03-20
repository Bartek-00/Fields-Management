namespace FieldsManagement.Core.Exceptions;

public class InvalidEmailException : BaseException
{
    public InvalidEmailException() : base("This isn't correct email")
    {
    }
}