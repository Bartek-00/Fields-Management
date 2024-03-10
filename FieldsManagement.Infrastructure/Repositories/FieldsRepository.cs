using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MongoDB.Driver;

namespace FieldsManagement.Infrastructure.Repositories;

public class FieldsRepository : IFieldsRepository
{
    private readonly IMongoCollection<Field> _collection;

    public FieldsRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Field>("Fields");
    }

    public async Task Create(Field fields)
        => await _collection.InsertOneAsync(fields);

    public async Task Update(Field fields)
        => await _collection.ReplaceOneAsync(x => x.FieldId == fields.FieldId, fields);

    public async Task Delete(Guid fieldId)
        => await _collection.DeleteOneAsync(x => x.FieldId == fieldId);

    public async Task<List<Field>> FindByVillageName(string villageName)
        => await _collection.Find(x => x.VillageName == villageName).ToListAsync();

    public async Task<Field> FindById(ObjectId fieldId)
        => await _collection.Find(x => x.FieldId == fieldId).FirstOrDefaultAsync();

    public async Task<List<Field>> GetAll()
        => await _collection.Find(x => true).ToListAsync();
}