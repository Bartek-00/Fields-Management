using FieldsManagement.Core.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace FieldsManagement.Core.Entities;

public class Operation
{
    public Operation(ObjectId fieldId, string operationName, string description, DateTime date)
    {
        ActionId = ObjectId.Create();
        FieldId = fieldId;
        OperationName = operationName;
        Description = description;
        Date = date;
    }

    [BsonId]
    public ObjectId ActionId { get; }

    public ObjectId FieldId { get; private set; }
    public OperationName OperationName { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }

    public void Update(string operationName, string description, DateTime date)
    {
        OperationName = operationName;
        Description = description;
        Date = date;
    }
}