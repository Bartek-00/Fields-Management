using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IFieldsRepository
{
    Task Create(Fields fields);

    Task Update(Fields fields);

    Task Delete(Guid Id);

    Task<List<Fields>> FindByVillageName(string villageName);

    Task<List<Fields>> GetAll();

    Task<Fields> FindById(Guid id);
}