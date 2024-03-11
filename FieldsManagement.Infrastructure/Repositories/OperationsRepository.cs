using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MongoDB.Driver;

namespace FieldsManagement.Infrastructure.Repositories;

public class OperationsRepository : IOperationRepository
{
    private readonly IMongoCollection<Operation> _collection;

    public OperationsRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Operation>("Operations");
    }

    public async Task Create(Operation operation)
        => await _collection.InsertOneAsync(operation);

    public async Task Update(Operation operation)
        => await _collection.FindOneAndReplaceAsync(x => x.OperationId == operation.OperationId, operation);

    public async Task Delete(Guid operationId)
        => await _collection.DeleteOneAsync(x => x.OperationId == operationId);

    public async Task<List<Operation>> GetAll()
        => await _collection.Find(x => true).ToListAsync();

    public async Task<List<Operation>> GetAllByFieldId(Guid fieldId)
        => await _collection.Find(x => x.FieldId == fieldId).ToListAsync();

    public async Task<Operation> GetByOperationId(Guid operationId)
    => await _collection.Find(x => x.OperationId == operationId).FirstOrDefaultAsync();
}