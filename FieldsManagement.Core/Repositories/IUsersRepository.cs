using FieldsManagement.Core.Entities;
using FieldsManagement.Core.ValueObjects;

namespace MySpot.Core.Repositories;

public interface IUsersRepository
{
    Task<User> GetByIdAsync(UserId id);

    Task<User> GetByEmailAsync(Email email);

    Task<User> GetByUsernameAsync(Username username);

    Task<IEnumerable<User>> GetAllAsync();

    Task AddAsync(User user);
}