using FieldsManagement.Core.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace FieldsManagement.Core.Entities
{
    public class Operation
    {
        [BsonId]
        public Guid OperationId { get; set; }
        public Guid FieldId { get; set; }
        public OperationName OperationName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Operation(Guid operationId, Guid fieldId, string operationName, string description, DateTime date)
        {
            OperationId = operationId;
            FieldId = fieldId;
            OperationName = operationName;
            Description = description;
            Date = date;
        }

        public void Update(string operationName, string description, DateTime date)
        {
            OperationName = operationName;
            Description = description;
            Date = date;
        }
    }
}