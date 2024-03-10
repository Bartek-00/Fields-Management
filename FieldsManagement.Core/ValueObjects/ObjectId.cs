using FieldsManagement.Core.Exceptions;
using System;

public sealed record ObjectId
{
    public Guid Value { get; }

    public ObjectId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new UncorrectGuidException();
        }
        Value = value;
    }

    public static ObjectId Create() => new(Guid.NewGuid());

    public static bool operator ==(ObjectId objectId, Guid guid)
        => objectId.Value == guid;

    public static bool operator !=(ObjectId objectId, Guid guid)
        => objectId.Value != guid;
}