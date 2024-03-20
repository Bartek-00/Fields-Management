using FieldsManagement.Core.Entities;
using MediatR;
using MySpot.Core.Repositories;

namespace FieldsManagement.Infrastructure.Queries.Users.Handler;

internal sealed class GetUserHandler(IUsersRepository usersRepository) : IRequestHandler<GetUser, User>
{
    public async Task<User> Handle(GetUser query, CancellationToken cancellationToken)
    {
        return await usersRepository.GetByIdAsync(query.UserId);
    }
}