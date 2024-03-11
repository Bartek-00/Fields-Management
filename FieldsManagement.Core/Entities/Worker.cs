using FieldsManagement.Core.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace FieldsManagement.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class Worker
    {
        public Worker(ObjectId objectId, WorkerName workerName, WorkerSurname workerSurname, string additionalData)
        {
            ObjectId = objectId;
            WorkerName = workerName;
            WorkerSurname = workerSurname;
            AdditionalData = additionalData;
        }

        [BsonId]
        public ObjectId ObjectId { get; private set; }

        public WorkerName WorkerName { get; private set; }
        public WorkerSurname WorkerSurname { get; private set; }
        public string AdditionalData { get; private set; }
    }
}