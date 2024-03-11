using FieldsManagement.Core.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace FieldsManagement.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class Worker
    {
        [BsonId]
        public Guid Id { get; private set; }

        public WorkerName WorkerName { get; private set; }
        public WorkerSurname WorkerSurname { get; private set; }
        public string AdditionalData { get; private set; }

        public Worker(Guid id, WorkerName workerName, WorkerSurname workerSurname, string additionalData)
        {
            Id = id;
            WorkerName = workerName;
            WorkerSurname = workerSurname;
            AdditionalData = additionalData;
        }
    }
}