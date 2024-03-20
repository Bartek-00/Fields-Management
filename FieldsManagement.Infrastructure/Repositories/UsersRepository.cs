using FieldsManagement.Application.DTO;
using FieldsManagement.Core.Entities;
using FieldsManagement.Core.ValueObjects;
using MongoDB.Driver;
using MySpot.Core.Repositories;

namespace FieldsManagement.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UsersRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<User>("Users");
        }

        public async Task<User> GetByIdAsync(UserId id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetByEmailAsync(Email email) =>
            await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<User> GetByUsernameAsync(Username username) =>
            await _collection.Find(x => x.Username == username).FirstOrDefaultAsync();

        public async Task AddAsync(User user) =>
            await _collection.InsertOneAsync(user);

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();
    }
}