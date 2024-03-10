using FieldsManagement.Core.ValueObjects;

namespace FieldsManagement.Core.Entities
{
    public class Worker
    {
        public Worker(ObjectId objectId, WorkerName workerName, WorkerSurname workerSurname, string additionalData)
        {
            ObjectId = objectId;
            WorkerName = workerName;
            WorkerSurname = workerSurname;
            AdditionalData = additionalData;
        }

        public ObjectId ObjectId { get; private set; }
        public WorkerName WorkerName { get; private set; }
        public WorkerSurname WorkerSurname { get; private set; }
        public string AdditionalData { get; private set; }
    }
}