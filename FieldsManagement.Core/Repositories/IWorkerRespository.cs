using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IWorkerRespository
{
    Task Create(Worker worker);

    Task Update(Worker worker);

    Task Delete(Guid workerId);

    Task<List<Worker>> GetAll();
}