namespace FieldsManagement.Core.Exceptions;

public sealed class UncorrectGuidException : BaseException
{
    public UncorrectGuidException() : base("This Guid isn't correct")
    {
    }
}