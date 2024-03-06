using FieldsManagement.Core.ValueObjects;

namespace FieldsManagement.Core.Entities
{
    public class Worker
    {
        public Worker(WorkerName workerName, WorkerSurname workerSurname, string additionalData)
        {
            WorkerName = workerName;
            WorkerSurname = workerSurname;
            AdditionalData = additionalData;
        }

        public WorkerName WorkerName { get; private set; }
        public WorkerSurname WorkerSurname { get; private set; }
        public string AdditionalData { get; private set; }
    }
}