using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Users;

public class GetUsers : IRequest<IEnumerable<User>>
{
}