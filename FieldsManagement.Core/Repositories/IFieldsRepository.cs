﻿using FieldsManagement.Core.Entities;

namespace FieldsManagement.Core.Repositories;

public interface IFieldsRepository
{
    Task Create(Field fields);

    Task Update(Field fields);

    Task Delete(Guid fieldId);

    Task<List<Field>> FindByVillageName(string villageName);

    Task<List<Field>> GetAll();

    Task<Field> FindById(Guid id);
}