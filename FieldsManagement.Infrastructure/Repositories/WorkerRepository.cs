﻿using FieldsManagement.Core.Entities;
using MongoDB.Driver;
using FieldsManagement.Core.Repositories;

namespace FieldsManagement.Infrastructure.Repositories;

public class WorkerRepository : IWorkerRespository
{
    private readonly IMongoCollection<Worker> _collection;

    public WorkerRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Worker>("Workers");
    }

    public async Task Create(Worker worker)
        => await _collection.InsertOneAsync(worker);

    public async Task Update(Worker worker)
        => await _collection.ReplaceOneAsync(x => x.ObjectId == worker.ObjectId, worker);

    public async Task Delete(Guid workerId)
        => await _collection.DeleteOneAsync(x => x.ObjectId == workerId);

    public async Task<List<Worker>> GetAll()
        => await _collection.Find(x => true).ToListAsync();
}