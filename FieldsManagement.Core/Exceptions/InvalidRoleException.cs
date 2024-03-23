namespace FieldsManagement.Core.Exceptions;

public class InvalidRoleException : BaseException
{
    public InvalidRoleException(string role) : base($"{role} role doesn't exist")
    {
    }
}