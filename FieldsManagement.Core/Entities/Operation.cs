using FieldsManagement.Core.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace FieldsManagement.Core.Entities
{
    public class Operation
    {
        [BsonId]
        public Guid OperationId { get; set; }

        public Guid FieldId { get; set; }
        public string PlantName { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Operation(Guid operationId, Guid fieldId, string plantName, string operationName, string description, DateTime date)
        {
            OperationId = operationId;
            FieldId = fieldId;
            PlantName = plantName;
            OperationName = operationName;
            Description = description;
            Date = date;
        }

        public void Update(string operationName, string plantName, string description, DateTime date)
        {
            OperationName = operationName;
            PlantName = plantName;
            Description = description;
            Date = date;
        }
    }
}