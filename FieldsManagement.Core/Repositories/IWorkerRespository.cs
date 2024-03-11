using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IWorkerRespository
{
    Task Create(Worker worker);

    Task Update(Worker worker);

    Task Delete(ObjectId workerId);

    Task<List<Worker>> GetAll();
}