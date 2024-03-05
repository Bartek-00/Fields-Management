using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MongoDB.Driver;

namespace FieldsManagement.Infrastructure.Repositories;

public class FieldsRepository : IFieldsRepository
{
    private readonly IMongoCollection<Fields> _collection;

    public FieldsRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Fields>("Fields");
    }

    public async Task Create(Fields fields)
        => await _collection.InsertOneAsync(fields);

    public async Task Update(Fields fields)
        => await _collection.ReplaceOneAsync(x => x.Id == fields.Id, fields);

    public async Task Delete(Guid Id)
        => await _collection.DeleteOneAsync(x => x.Id == Id);

    public async Task<List<Fields>> FindByVillageName(string villageName)
        => await _collection.Find(x => x.VillageName == villageName).ToListAsync();

    public async Task<Fields> FindById(Guid id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<Fields>> GetAll()
        => await _collection.Find(x => true).ToListAsync();
}