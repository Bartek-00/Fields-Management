using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IOperationRepository
{
    Task Create(Operation operation);

    Task Update(Operation operation);

    Task Delete(ObjectId actionId);

    Task<List<Operation>> GetAll();

    Task<List<Operation>> GetAllByFieldId(ObjectId fieldId);

    Task<Operation> GetByOperationId(ObjectId actionId);
}