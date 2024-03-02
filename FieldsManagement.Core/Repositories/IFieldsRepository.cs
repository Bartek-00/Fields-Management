using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IFieldsRepository
{
    Task Create(Fields fields);

    Task Update(Fields fields);

    Task Delete(Fields fields);

    Task FindByVillageName(string villageName);
}