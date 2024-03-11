using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Operations;

public record GetOperationsByFieldIdQuery(ObjectId FieldId) : IRequest<List<Operation>>;