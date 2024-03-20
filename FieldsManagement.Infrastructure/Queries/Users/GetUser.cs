using FieldsManagement.Application.DTO;
using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Users;

public class GetUser : IRequest<User>
{
    public Guid UserId { get; set; }
}