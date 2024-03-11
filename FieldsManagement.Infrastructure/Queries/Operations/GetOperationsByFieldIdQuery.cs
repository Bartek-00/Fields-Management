using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Operations;

public record GetOperationsByFieldIdQuery(Guid FieldId) : IRequest<List<Operation>>;