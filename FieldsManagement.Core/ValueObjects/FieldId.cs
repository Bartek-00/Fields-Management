using FieldsManagement.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record FieldId
{
    public Guid Value { get; }

    public FieldId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new UncorrectGuidException();
        }
        Value = value;
    }

    public static FieldId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(FieldId date)
        => date.Value;

    public static implicit operator FieldId(Guid value)
        => new(value);
}