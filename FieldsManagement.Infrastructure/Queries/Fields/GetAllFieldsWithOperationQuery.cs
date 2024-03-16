using FieldsManagement.Application.DTO;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Fields;

public record GetAllFieldsWithOperationQuery : IRequest<IEnumerable<FieldDTO>>
{
}