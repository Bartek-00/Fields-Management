using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IOperationRepository
{
    Task Create(Operation operation);

    Task Update(Operation operation);

    Task Delete(Guid actionId);

    Task<List<Operation>> GetAll();

    Task<List<Operation>> GetAllByFieldId(Guid fieldId);

    Task<Operation> GetByOperationId(Guid actionId);
}