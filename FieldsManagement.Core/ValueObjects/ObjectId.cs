using FieldsManagement.Core.Exceptions;
using System.Text.Json.Serialization;

public record ObjectId
{
    public Guid Value { get; }

    [JsonConstructor]
    public ObjectId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new UncorrectGuidException();
        }
        Value = value;
    }

    public ObjectId(ObjectId objectId)
    {
        Value = objectId.Value;
    }

    public static ObjectId Create() => new(Guid.NewGuid());

    public static bool operator ==(ObjectId objectId, Guid guid)
        => objectId.Value == guid;

    public static bool operator !=(ObjectId objectId, Guid guid)
        => objectId.Value != guid;
}