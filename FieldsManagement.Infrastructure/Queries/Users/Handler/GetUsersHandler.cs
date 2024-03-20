using FieldsManagement.Core.Entities;
using MediatR;
using MySpot.Core.Repositories;

namespace FieldsManagement.Infrastructure.Queries.Users.Handler;

internal sealed class GetUsersHandler(IUsersRepository usersRepository) : IRequestHandler<GetUsers, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetUsers query, CancellationToken cancellationToken)
    {
        return await usersRepository.GetAllAsync();
    }
}